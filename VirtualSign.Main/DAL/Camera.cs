using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VirtualSign.Main.Business;

namespace VirtualSign.Main.DAL
{
  class Camera
  {
    private ImageProcessing _impro;
    private Label _fps;
    private Label _avgFps;
    private Mat _frame;
    private PictureBox _pictureBox;
    private Stopwatch _watch;
    private VideoCapture _capture;
    private bool _isCameraRunning;
    private int _stackSize;
    private int _stackCursor;
    private int[] _fpsStack;

    /// <summary>
    /// Access Camera and Control It
    /// </summary>
    /// <param name="pictureBox"></param>
    /// <param name="fps"></param>
    /// <param name="avgFps"></param>
    public Camera(PictureBox pictureBox, Label fps, Label avgFps)
    {
      _stackSize = 50;
      _stackCursor = 0;

      _impro = new ImageProcessing();
      _pictureBox = pictureBox;
      _fps = fps;
      _avgFps = avgFps;
      _fpsStack = new int[_stackSize];
    }

    public void StreamCamera()
    {
      int fps;
      InitCamera();
      if (_capture.IsOpened())
      {
        while (_isCameraRunning)
        {
          Bitmap img= ReadImageFromCamera();
          img = _impro.ConvertToGrayscale(img);
          UpdateFrameOnUI(img);
          fps = GetFPS();
          ResetStopWatch();
          UpdateFPSLabel(fps);
          AddFpsStack(fps);
          UpdateFPSAverageLabel();
        }
      }
    }

    private void InitCamera()
    {
      _isCameraRunning = true;
      _frame = new Mat();
      _capture = new VideoCapture(0);
      _watch = new Stopwatch();
      _capture.Open(0);
    }

    private Bitmap ReadImageFromCamera()
    {
      Bitmap image;
      _watch.Start();
      _capture.Read(_frame);
      image = BitmapConverter.ToBitmap(_frame);

      return image;
    }

    private void UpdateFrameOnUI(Bitmap img)
    {
      if (_pictureBox.Image != null)
      {
        _pictureBox.Invoke(new Action(() => _pictureBox.Image.Dispose()));
      }
      _pictureBox.Invoke(new Action(() => _pictureBox.Image = img));
    }

    private int GetFPS()
    {
      TimeSpan time = _watch.Elapsed;
      return (int)(1000D/time.TotalMilliseconds);
    }

    private void ResetStopWatch()
    {
      _watch.Reset();
    }

    private void UpdateFPSLabel(int fps)
    {
      _fps.Invoke(new Action(() =>
      {
        _fps.Text = fps.ToString();
      }));
    }

    private void UpdateFPSAverageLabel()
    {
      _avgFps.Invoke(new Action(() => _avgFps.Text = GetFPSAverage().ToString()));
    }

    private void AddFpsStack(int fps)
    {
      _stackCursor = (_stackCursor >= _stackSize - 1) ? _stackCursor = 0 : _stackCursor += 1;
      _fpsStack[_stackCursor] = fps;
    }

    private int GetFPSAverage()
    {
      int total = 0;
      int i = 0;
      foreach (int fps in _fpsStack)
      {
        if (fps != 0)
        {
          total += fps;
          i++;
        }
      }
      return total/i;
    }

    public void Release()
    {
      _isCameraRunning = false;
      _capture.Release();
    }
  }
}
