using System;
using System.Threading;
using System.Windows.Forms;
using VirtualSign.Main.DAL;

namespace VirtualSign.Main
{
  public partial class UI : Form
  {
    private Thread _thread;
    private Camera _camera;

    public UI()
    {
      InitializeComponent();
      _camera = new Camera(pictureBox1, fps, averageFps);
    }

    /// <summary>
    /// Called by clickling Start button, automatically change the text to Stop when started
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StartButtonClick(object sender, EventArgs e)
    {
      if (button1.Text.Equals("Start"))
      {
        DoCaptureCamera();
        button1.Text = "Stop";
      }
      else
      {
        _camera.Release();
        button1.Text = "Start";
      }
    }

    /// <summary>
    /// Adding new thread about capturing camera
    /// </summary>
    private void DoCaptureCamera()
    {
      _thread = new Thread(new ThreadStart(
        () => _camera.StreamCamera()));
      _thread.Start();
    }
  }
}
