#include <opencv2/core.hpp>
#include <opencv2/videoio.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <iostream>
#include <stdio.h>

using namespace std;


int main(int, char**)
{
    cv::Mat frame;
    cv::Mat hsvFrame;
    cv::Mat threshFrame;
    cv::VideoCapture cap;
    
    int deviceID = 0;
    int apiID = cv::CAP_ANY;
    
    cap.open(deviceID, apiID);
    
    if (!cap.isOpened()) {
        cerr << "ERROR! Unable to open camera\n";
        return -1;
    }
    
    cout << "Start grabbing" << endl
        << "Press any key to terminate" << endl;
    while (true)
    {
        cap.read(frame);
        cv::cvtColor(frame, hsvFrame, cv::COLOR_BGR2HSV);
        cv::inRange(hsvFrame, cv::Scalar(10, 10, 100), cv::Scalar(20, 20, 150), threshFrame);
        if (frame.empty()) {
            cerr << "ERROR! blank frame grabbed\n";
            break;
        }
        imshow("Live", threshFrame);
        if (cv::waitKey(5) >= 0)
            break;
    }
    return 0;
}
