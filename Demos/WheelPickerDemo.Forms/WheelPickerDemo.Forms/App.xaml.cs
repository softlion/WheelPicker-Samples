using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    public partial class App : Application
    {
        public App()
        {
            Vapolia.WheelPickerCore.Config.License = "eyJhbGciOiJSUzI1NiIsImtpZCI6InZhcG9saWFzaWciLCJ0eXAiOiJKV1QifQ.eyJodHRwczovL3NjaGVtYXMudmFwb2xpYS5ldS8yMDIwLzA1L2NsYWltcy9MaWNlbnNlc0NsYWltIjoie1wiTGljZW5zZXNcIjpbe1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJcIixcIk9zXCI6XCJpb3NcIixcIkFwcElkXCI6XCJjb20udmFwb2xpYS5XaGVlbFBpY2tlckRlbW9Gb3Jtc1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwiYW5kcm9pZFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLldoZWVsUGlja2VyRGVtb0Zvcm1zXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJcIixcIk9zXCI6XCJ1d3BcIixcIkFwcElkXCI6XCJjb20udmFwb2xpYS5XaGVlbFBpY2tlckRlbW9Gb3Jtc1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyZm9ybXNcIixcIk9zXCI6XCJpb3NcIixcIkFwcElkXCI6XCJjb20udmFwb2xpYS5XaGVlbFBpY2tlckRlbW9Gb3Jtc1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyZm9ybXNcIixcIk9zXCI6XCJhbmRyb2lkXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEuV2hlZWxQaWNrZXJEZW1vRm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlcmZvcm1zXCIsXCJPc1wiOlwidXdwXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEuV2hlZWxQaWNrZXJEZW1vRm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlclwiLFwiT3NcIjpcImlvc1wiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwiYW5kcm9pZFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwidXdwXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJmb3Jtc1wiLFwiT3NcIjpcImlvc1wiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyZm9ybXNcIixcIk9zXCI6XCJhbmRyb2lkXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJmb3Jtc1wiLFwiT3NcIjpcInV3cFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwiaW9zXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vZm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlclwiLFwiT3NcIjpcImFuZHJvaWRcIixcIkFwcElkXCI6XCJjb20udmFwb2xpYS53aGVlbHBpY2tlcmRlbW9mb3Jtc1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwidXdwXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vZm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlcmZvcm1zXCIsXCJPc1wiOlwiaW9zXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vZm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlcmZvcm1zXCIsXCJPc1wiOlwiYW5kcm9pZFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb2Zvcm1zXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJmb3Jtc1wiLFwiT3NcIjpcInV3cFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb2Zvcm1zXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn1dfSIsIm5iZiI6MTU5NDMxODM5NiwiZXhwIjoxOTA5ODUxMTk2LCJpYXQiOjE1OTQzMTgzOTYsImlzcyI6Imh0dHBzOi8vdmFwb2xpYS5ldS9hdXRob3JpdHkiLCJhdWQiOiJodHRwczovL3ZhcG9saWEuZXUvYXV0aG9yaXR5L2xpY2Vuc2VzIn0.qsktxo6OA0HNQU0TVnVxzQ0j6zoMw3CSbwTzhRfkQ3jmHnYk3N1pcnRobcP69h-9P8X3M9Ye-2iflq5Kkdv36unwp4B6X6HLpFlz1su9doMQmlHkea1HkNXip2o3BCgCOWFHDVdVLYV9D-AQtspiuiOTthgRezYvqt1kLtfM3qfrjKw7tTXv2TAX91T8-iNRb3OSc9TQeHESPBDTYYFDV6SHUECRSuOH8_-V5gUtxoIS7c1xMOJkdty-L8pYGn45BmtdaL3bMdXY_eYQwq7uYIxRHPcQ-KEioqtyU158Jzh4uX14OjcBkQ2Bz1Qhd6rFNz8Q0EpZ2roNfoNpqLX-XQ";
            InitializeComponent();

            MainPage = new MainContainer();
        }
    }

    class VapoliaLicense
    {
        /// <summary>
        /// product targeted by this license
        /// </summary>
        /// <example>
        /// xamsvg, wheelpicker, xamsvgforms, wheelpickerforms, ...
        /// </example>
        public string Product { get; set; }

        /// <summary>
        /// OS on which this license can be used
        /// </summary>
        public string Os { get; set; }

        /// <summary>
        /// Application id that can use this license
        /// </summary>
        /// <remarks>
        /// android: Android.App.Application.Context.PackageName;
        /// ios: NSBundle.MainBundle.BundleIdentifier;
        /// </remarks>
        public string AppId { get; set; }

        /// <summary>
        /// Max product build date with which this license can be used
        /// </summary>
        public DateTimeOffset MaxBuild { get; set; }
    }

    class VapoliaLicenses
    {
        public List<VapoliaLicense> Licenses { get; set; }
    }
}
