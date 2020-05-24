using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    public partial class App : Application
    {
        public App()
        {
            Vapolia.WheelPickerCore.Config.License = "eyJhbGciOiJSUzI1NiIsImtpZCI6InZhcG9saWFzaWciLCJ0eXAiOiJKV1QifQ.eyJ1bmlxdWVfbmFtZSI6ImQ0NjUzYWY0OTRlMDQyZWE5NTY5Y2U5N2I0ZjQ2NzFjIiwiaHR0cHM6Ly9zY2hlbWFzLnZhcG9saWEuZXUvMjAyMC8wNS9jbGFpbXMvTWF4QnVpbGREYXRlQ2xhaW0iOiIyMDIxLTA1LTI0VDE3OjA3OjMzLjQxODUzODcrMDI6MDAiLCJodHRwczovL3NjaGVtYXMudmFwb2xpYS5ldS8yMDIwLzA1L2NsYWltcy9Qcm9kdWN0Q29kZUNsYWltIjpbIndoZWVscGlja2VyIiwid2hlZWxwaWNrZXJmb3JtcyJdLCJodHRwczovL3NjaGVtYXMudmFwb2xpYS5ldS8yMDIwLzA1L2NsYWltcy9BcHBJZENsYWltIjpbImNvbS52YXBvbGlhLldoZWVsUGlja2VyRGVtb0Zvcm1zIiwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vIiwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vZm9ybXMiXSwiaHR0cHM6Ly9zY2hlbWFzLnZhcG9saWEuZXUvMjAyMC8wNS9jbGFpbXMvT3NDbGFpbSI6WyJpb3MiLCJhbmRyb2lkIiwidXdwIl0sIm5iZiI6MTU5MDMzMjg1MywiZXhwIjoxOTA1ODY1NjUzLCJpYXQiOjE1OTAzMzI4NTMsImlzcyI6Imh0dHBzOi8vdmFwb2xpYS5ldS9hdXRob3JpdHkiLCJhdWQiOiJodHRwczovL3ZhcG9saWEuZXUvYXV0aG9yaXR5L2xpY2Vuc2VzIn0.fdy9VcxKMp8Tki90x0fk5XaAKZEKitvV0hO_qhGlq8P5T-Zq5_y1yX0xWo1lrwS5iQ9xD0YtPbdBspM_s2M0jwVKJXyiTJb30GNOzyEOoSIjldkIJ1S9rlWtJebAcdPTyJAJmqgESDgmhKC-YV0Ecce7EpkZUY9OodG2lY2h4zLJme6DY3zNewZEBUIRUANsF2sn6OFz97iez0P-RMwfB_o5_Hbe-wLhOCx1letQXOcvMuhrId02ClH1oNcUlqUtJR_fzhnlfXXnsxbLaMglnJiuW5UhWP_0b-5wZHyizH72ndZxZaS2cRkFy1DCkzva81f1jutjbbXaSB311VaaFw";
            InitializeComponent();

            MainPage = new MainContainer();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
