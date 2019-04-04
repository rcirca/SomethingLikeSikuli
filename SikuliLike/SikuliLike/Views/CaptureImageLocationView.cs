using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SikuliLike.Util;
using SikuliLike.Util.Enums;
using SikuliLike.Views.Interfaces;
using SikuliLike.Views.Intermediaries;

namespace SikuliLike.Views
{
    public partial class CaptureImageLocationView : CaptureImageLocationIntermediary, ICaptureView
    {
        
        #region Member Variables
        private CaptureClickAction _currentAction;
        private bool _leftButtonDown;
        private bool _rectangleDrawn;
        private bool _readyToDrag = false;
        private string _screenPath;

        private Point _clickPoint;
        private Point _currentTopLeft = new Point();
        private Point _currentBottomRight = new Point();

        private Point _cragClickRelative;

        private int _rectangleHeight;
        private int _rectangleWidth;

        private readonly Graphics _graphics;
        private readonly Pen _penMarkup = new Pen(Color.Black, 1);
        private SolidBrush _transparentBrush = new SolidBrush(Color.White);
        private readonly Pen _eraserPenMarkup = new Pen(Color.FromArgb(255, 255, 192), 1);
        private SolidBrush _eraserBrushMarkup = new SolidBrush(Color.FromArgb(255, 255, 192));
        #endregion

        #region Constructors

        public CaptureImageLocationView()
        {
            InitializeComponent();
            MouseDown += MousePressedDown;
            MouseDoubleClick += MouseDoubleClicked;
            MouseUp += MouseReleased;
            MouseMove += MouseMoved;
            KeyUp += KeyReleased;
            _graphics = CreateGraphics();
        }

        public ImageLocation ImageLocation { get; private set; }
        #endregion

        private void SetClickAction()
        {
            switch (GetCursorPosition())
            {
                case CursorPosition.BottomLine: _currentAction = CaptureClickAction.BottomSizing;
                    break;
                case CursorPosition.TopLine: _currentAction = CaptureClickAction.TopSizing;
                    break;
                case CursorPosition.LeftLine: _currentAction = CaptureClickAction.LeftSizing;
                    break;
                case CursorPosition.TopLeft: _currentAction = CaptureClickAction.TopLeftSizing;
                    break;
                case CursorPosition.BottomLeft: _currentAction = CaptureClickAction.BottomLeftSizing;
                    break;
                case CursorPosition.RightLine: _currentAction = CaptureClickAction.RightSizing;
                    break;
                case CursorPosition.TopRight:  _currentAction = CaptureClickAction.TopRightSizing;
                    break;
                case CursorPosition.BottomRight: _currentAction = CaptureClickAction.BottomRightSizing;
                    break;
                case CursorPosition.WithinSelectionArea:  _currentAction = CaptureClickAction.Dragging;
                    break;
                case CursorPosition.OutsideSelectionArea: _currentAction = CaptureClickAction.Outside;
                    break;
            }
        }

        private bool IsLeftLine()
        {
            return Cursor.Position.X > _currentTopLeft.X - 10 &&
                   Cursor.Position.X < _currentTopLeft.X + 10 &&
                   Cursor.Position.Y > _currentTopLeft.Y + 10 &&
                   Cursor.Position.Y < _currentBottomRight.Y - 10;
        }
        private bool IsTopLeft()
        {
            return Cursor.Position.X >= _currentTopLeft.X - 10 &&
                   Cursor.Position.X <= _currentTopLeft.X + 10 &&
                   Cursor.Position.Y >= _currentTopLeft.Y - 10 &&
                   Cursor.Position.Y <= _currentTopLeft.Y + 10;
        }

        private bool IsBottomLeft()
        {
            return Cursor.Position.X >= _currentTopLeft.X - 10 &&
                   Cursor.Position.X <= _currentTopLeft.X + 10 &&
                   Cursor.Position.Y >= _currentBottomRight.Y - 10 &&
                   Cursor.Position.Y <= _currentBottomRight.Y + 10;
        }

        private bool IsRightLine()
        {
            return Cursor.Position.X > _currentBottomRight.X - 10 &&
                   Cursor.Position.X < _currentBottomRight.X + 10 &&
                   Cursor.Position.Y > _currentTopLeft.Y + 10 &&
                   Cursor.Position.Y < _currentBottomRight.Y - 10;
        }

        private bool IsTopRight()
        {
            return Cursor.Position.X >= _currentBottomRight.X - 10 &&
                   Cursor.Position.X <= _currentBottomRight.X + 10 &&
                   Cursor.Position.Y >= _currentTopLeft.Y - 10 &&
                   Cursor.Position.Y <= _currentTopLeft.Y + 10;
        }

        private bool IsBottomRight()
        {
            return Cursor.Position.X >= _currentBottomRight.X - 10 &&
                   Cursor.Position.X <= _currentBottomRight.X + 10 &&
                   Cursor.Position.Y >= _currentBottomRight.Y - 10 &&
                   Cursor.Position.Y <= _currentBottomRight.Y + 10;
        }

        private bool IsTopLine()
        {
            return Cursor.Position.Y > _currentTopLeft.Y - 10 &&
                   Cursor.Position.Y < _currentTopLeft.Y + 10 &&
                   Cursor.Position.X > _currentTopLeft.X + 10 &&
                   Cursor.Position.X < _currentBottomRight.X - 10;
        }

        private bool IsBottomLine()
        {
            return Cursor.Position.Y > _currentBottomRight.Y - 10 &&
                   Cursor.Position.Y < _currentBottomRight.Y + 10 &&
                   Cursor.Position.X > _currentTopLeft.X + 10 &&
                   Cursor.Position.X < _currentBottomRight.X - 10;
        }

        private bool IsInSelectionArea()
        {
            return Cursor.Position.X >= _currentTopLeft.X + 10 &&
                   Cursor.Position.X <= _currentBottomRight.X - 10 &&
                   Cursor.Position.Y >= _currentTopLeft.Y + 10 &&
                   Cursor.Position.Y <= _currentBottomRight.Y - 10;
        }

        private CursorPosition GetCursorPosition()
        {
            if (IsLeftLine())
            {
                Cursor = Cursors.SizeWE;
                return CursorPosition.LeftLine;
            }

            if (IsTopLeft())
            {
                Cursor = Cursors.SizeNWSE;
                return CursorPosition.TopLeft;
            }

            if (IsBottomLeft())
            {
                Cursor = Cursors.SizeNESW;
                return CursorPosition.BottomLeft;
            }

            if (IsRightLine())
            {
                Cursor = Cursors.SizeWE;
                return CursorPosition.RightLine;
            }

            if (IsTopRight())
            {
                Cursor = Cursors.SizeNESW;
                return CursorPosition.TopRight;
            }

            if (IsBottomRight())
            {
                Cursor = Cursors.SizeNWSE;
                return CursorPosition.BottomRight;
            }

            if (IsTopLine())
            {
                Cursor = Cursors.SizeNS;
                return CursorPosition.TopLine;
            }

            if (IsBottomLine())
            {
                Cursor = Cursors.SizeNS;
                return CursorPosition.BottomLine;
            }

            if (IsInSelectionArea())
            {
                Cursor = Cursors.Hand;
                return CursorPosition.WithinSelectionArea;
            }

            Cursor = Cursors.No;
            return CursorPosition.OutsideSelectionArea;
        }

        private void ResizeSelection()
        {
            if (_currentAction == CaptureClickAction.LeftSizing)
                if (Cursor.Position.X < _currentBottomRight.X - 10)
                {
                    //Erase the previous rectangle
                    _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth,
                        _rectangleHeight);
                    _currentTopLeft.X = Cursor.Position.X;
                    _rectangleWidth = _currentBottomRight.X - _currentTopLeft.X;
                    _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth, _rectangleHeight);
                }
            if (_currentAction == CaptureClickAction.TopLeftSizing)
                if (Cursor.Position.X < _currentBottomRight.X - 10 &&
                    Cursor.Position.Y < _currentBottomRight.Y - 10)
                {
                    //Erase the previous rectangle
                    _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth,
                        _rectangleHeight);
                    _currentTopLeft.X = Cursor.Position.X;
                    _currentTopLeft.Y = Cursor.Position.Y;
                    _rectangleWidth = _currentBottomRight.X - _currentTopLeft.X;
                    _rectangleHeight = _currentBottomRight.Y - _currentTopLeft.Y;
                    _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth, _rectangleHeight);
                }
            if (_currentAction == CaptureClickAction.BottomLeftSizing)
                if (Cursor.Position.X < _currentBottomRight.X - 10 &&
                    Cursor.Position.Y > _currentTopLeft.Y + 10)
                {
                    //Erase the previous rectangle
                    _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth,
                        _rectangleHeight);
                    _currentTopLeft.X = Cursor.Position.X;
                    _currentBottomRight.Y = Cursor.Position.Y;
                    _rectangleWidth = _currentBottomRight.X - _currentTopLeft.X;
                    _rectangleHeight = _currentBottomRight.Y - _currentTopLeft.Y;
                    _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth, _rectangleHeight);
                }
            if (_currentAction == CaptureClickAction.RightSizing)
                if (Cursor.Position.X > _currentTopLeft.X + 10)
                {
                    //Erase the previous rectangle
                    _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth,
                        _rectangleHeight);
                    _currentBottomRight.X = Cursor.Position.X;
                    _rectangleWidth = _currentBottomRight.X - _currentTopLeft.X;
                    _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth, _rectangleHeight);
                }
            if (_currentAction == CaptureClickAction.TopRightSizing)
                if (Cursor.Position.X > _currentTopLeft.X + 10 &&
                    Cursor.Position.Y < _currentBottomRight.Y - 10)
                {
                    //Erase the previous rectangle
                    _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth,
                        _rectangleHeight);
                    _currentBottomRight.X = Cursor.Position.X;
                    _currentTopLeft.Y = Cursor.Position.Y;
                    _rectangleWidth = _currentBottomRight.X - _currentTopLeft.X;
                    _rectangleHeight = _currentBottomRight.Y - _currentTopLeft.Y;
                    _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth, _rectangleHeight);
                }
            if (_currentAction == CaptureClickAction.BottomRightSizing)
                if (Cursor.Position.X > _currentTopLeft.X + 10 &&
                    Cursor.Position.Y > _currentTopLeft.Y + 10)
                {
                    //Erase the previous rectangle
                    _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth,
                        _rectangleHeight);
                    _currentBottomRight.X = Cursor.Position.X;
                    _currentBottomRight.Y = Cursor.Position.Y;
                    _rectangleWidth = _currentBottomRight.X - _currentTopLeft.X;
                    _rectangleHeight = _currentBottomRight.Y - _currentTopLeft.Y;
                    _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth, _rectangleHeight);
                }
            if (_currentAction == CaptureClickAction.TopSizing)
                if (Cursor.Position.Y < _currentBottomRight.Y - 10)
                {
                    //Erase the previous rectangle
                    _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth,
                        _rectangleHeight);
                    _currentTopLeft.Y = Cursor.Position.Y;
                    _rectangleHeight = _currentBottomRight.Y - _currentTopLeft.Y;
                    _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth, _rectangleHeight);
                }
            if (_currentAction == CaptureClickAction.BottomSizing)
                if (Cursor.Position.Y > _currentTopLeft.Y + 10)
                {
                    //Erase the previous rectangle
                    _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth,
                        _rectangleHeight);
                    _currentBottomRight.Y = Cursor.Position.Y;
                    _rectangleHeight = _currentBottomRight.Y - _currentTopLeft.Y;
                    _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                        _rectangleWidth, _rectangleHeight);
                }
        }

        private void DrawSelection()
        {
            Cursor = Cursors.Arrow;
            
            _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                _currentBottomRight.X - _currentTopLeft.X,
                _currentBottomRight.Y - _currentTopLeft.Y);
            
            if (Cursor.Position.X < _clickPoint.X)
            {
                _currentTopLeft.X = Cursor.Position.X;
                _currentBottomRight.X = _clickPoint.X;
            }
            else
            {
                _currentTopLeft.X = _clickPoint.X;
                _currentBottomRight.X = Cursor.Position.X;
            }
            
            if (Cursor.Position.Y < _clickPoint.Y)
            {
                _currentTopLeft.Y = Cursor.Position.Y;
                _currentBottomRight.Y = _clickPoint.Y;
            }
            else
            {
                _currentTopLeft.Y = _clickPoint.Y;
                _currentBottomRight.Y = Cursor.Position.Y;
            }

            _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                _currentBottomRight.X - _currentTopLeft.X,
                _currentBottomRight.Y - _currentTopLeft.Y);
        }

        private void DragSelection()
        {
            //Ensure that the rectangle stays within the bounds of the screen

            //Erase the previous rectangle
            _graphics.DrawRectangle(_eraserPenMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                _rectangleWidth, _rectangleHeight);

            if (Cursor.Position.X - _cragClickRelative.X > 0 &&
                Cursor.Position.X - _cragClickRelative.X + _rectangleWidth <
                Screen.PrimaryScreen.Bounds.Width)
            {
                _currentTopLeft.X = Cursor.Position.X - _cragClickRelative.X;
                _currentBottomRight.X = _currentTopLeft.X + _rectangleWidth;
            }
            else if (Cursor.Position.X - _cragClickRelative.X > 0) //Selection area has reached the right side of the screen
            {
                _currentTopLeft.X = Screen.PrimaryScreen.Bounds.Width - _rectangleWidth;
                _currentBottomRight.X = _currentTopLeft.X + _rectangleWidth;
            }
            else //Selection area has reached the left side of the screen
            {
                _currentTopLeft.X = 0;
                _currentBottomRight.X = _currentTopLeft.X + _rectangleWidth;
            }

            if (Cursor.Position.Y - _cragClickRelative.Y > 0 &&
                Cursor.Position.Y - _cragClickRelative.Y + _rectangleHeight < Screen.PrimaryScreen.Bounds.Height)
            {
                _currentTopLeft.Y = Cursor.Position.Y - _cragClickRelative.Y;
                _currentBottomRight.Y = _currentTopLeft.Y + _rectangleHeight;
            }
            else if (Cursor.Position.Y - _cragClickRelative.Y > 0) //Selection area has reached the bottom of the screen
            {
                _currentTopLeft.Y = Screen.PrimaryScreen.Bounds.Height - _rectangleHeight;
                _currentBottomRight.Y = _currentTopLeft.Y + _rectangleHeight;
            }
            else //Selection area has reached the top of the screen
            {
                _currentTopLeft.Y = 0;
                _currentBottomRight.Y = _currentTopLeft.Y + _rectangleHeight;
            }

            //Draw a new rectangle
            _graphics.DrawRectangle(_penMarkup, _currentTopLeft.X, _currentTopLeft.Y,
                _rectangleWidth, _rectangleHeight);
        }

        public void SaveScreenShot()
        {
            Model.CurrentTopLeft = _currentTopLeft;
            Model.CurrentBottomRight = _currentBottomRight;
            SaveSelection?.Invoke(this, EventArgs.Empty);
            ImageLocation = Model.NewImageLocation;
            DialogResult = DialogResult.OK;
        }

        #region Implementation
        private void MouseMoved(object sender, MouseEventArgs e)
        {
            if (_leftButtonDown && !_rectangleDrawn)
                DrawSelection();

            if (_rectangleDrawn)
            {
                GetCursorPosition();

                if (_currentAction == CaptureClickAction.Dragging)
                    DragSelection();

                if (_currentAction != CaptureClickAction.Dragging && _currentAction != CaptureClickAction.Outside)
                    ResizeSelection();
            }
        }

        private void KeyReleased(object pSender, KeyEventArgs pKeyEventArgs)
        {
            if (pKeyEventArgs.KeyCode == Keys.S && _rectangleDrawn &&
                (GetCursorPosition() == CursorPosition.WithinSelectionArea ||
                 GetCursorPosition() == CursorPosition.OutsideSelectionArea))
            {
                SaveScreenShot();
            }

            if (pKeyEventArgs.KeyCode == Keys.Q)
            {
                DialogResult = DialogResult.Abort;
            }

        }

        private void MouseReleased(object pSender, MouseEventArgs pMouseEventArgs)
        {
            SaveScreenShot();
            _rectangleDrawn = true;
            _leftButtonDown = false;
            _currentAction = CaptureClickAction.NoClick;
            _rectangleDrawn = false;
        }

        private void MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            if (_rectangleDrawn &&
                (GetCursorPosition() == CursorPosition.WithinSelectionArea
                 || GetCursorPosition() == CursorPosition.OutsideSelectionArea))
            {
                SaveScreenShot();
            }
        }

        private void MousePressedDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetClickAction();
                _leftButtonDown = true;
                _clickPoint = new Point(MousePosition.X,
                    MousePosition.Y);

                if (_rectangleDrawn)
                {
                    _rectangleHeight = _currentBottomRight.Y - _currentTopLeft.Y;
                    _rectangleWidth = _currentBottomRight.X - _currentTopLeft.X;
                    _cragClickRelative.X = Cursor.Position.X - _currentTopLeft.X;
                    _cragClickRelative.Y = Cursor.Position.Y - _currentTopLeft.Y;
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs pMouseEventArgs)
        {
            if (pMouseEventArgs.Button == MouseButtons.Right)
                pMouseEventArgs = null;

            base.OnMouseClick(pMouseEventArgs);
        }

        #endregion

        public event EventHandler SaveSelection;
    }
}
