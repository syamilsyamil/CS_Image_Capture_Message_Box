using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class window_model : Exception{
        public string testMsg = "Testing";
        public string clickMsg = "Click pass or fail Now";
        public string fileExe = "Image Files(*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
        public string badAlert = "You should select image then only you can zoom";
        public string rootImage = "C:\\Users\\Public\\Pictures\\Sample Pictures\\";
        public string exe = ".jpg";
        public string space = " ";
        public string LD_Compare = "LD Compare";
        public void Initialize(string a,string b,string c,string d,string e,string f,string g,string h) {
            this.testMsg = a;
            this.fileExe = b;
            this.badAlert = c;
            this.rootImage = d;
            this.exe = e;
            this.space = f;
            this.clickMsg = g;
            this.LD_Compare = h;
        }
    }
}
