﻿using Microsoft.Extensions.Logging;
using Vapolia.Svgs;
using Vapolia.WheelPickers;

namespace WheelPickerMauiDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseWheelPicker("eyJhbGciOiJSUzI1NiIsImtpZCI6InZhcG9saWFzaWciLCJ0eXAiOiJKV1QifQ.eyJodHRwczovL3NjaGVtYXMudmFwb2xpYS5ldS8yMDIwLzA1L2NsYWltcy9MaWNlbnNlc0NsYWltIjoie1wiTGljZW5zZXNcIjpbe1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJcIixcIk9zXCI6XCJpb3NcIixcIkFwcElkXCI6XCJldS52YXBvbGlhLndoZWVscGlja2VybWF1aWRlbW9cIixcIk1heEJ1aWxkXCI6XCIyMDI0LTEwLTMxVDA4OjQzOjA3Ljg5NTI1NTYrMDE6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJcIixcIk9zXCI6XCJhbmRyb2lkXCIsXCJBcHBJZFwiOlwiZXUudmFwb2xpYS53aGVlbHBpY2tlcm1hdWlkZW1vXCIsXCJNYXhCdWlsZFwiOlwiMjAyNC0xMC0zMVQwODo0MzowNy44OTUyNTU2KzAxOjAwXCJ9XX0iLCJuYmYiOjE2OTg4MjQ1ODcsImV4cCI6MjAxNDQ0Mzc4NywiaWF0IjoxNjk4ODI0NTg3LCJpc3MiOiJodHRwczovL3ZhcG9saWEuZXUvYXV0aG9yaXR5IiwiYXVkIjoiaHR0cHM6Ly92YXBvbGlhLmV1L2F1dGhvcml0eS9saWNlbnNlcyJ9.rxGGfxzg0QvbjAY3DDqHkaWISzyctgfoI7SeiqBMy2IoffOT1IbeB0i4C9_-CNeS2kfSUkJIwY_kPC2MWRtErOsyZ0CmECPlWNDa_0gjr2cJTzFC59mxtiDthTAWDWpL1r2U9W1vrYkF2q9sEXzPAFKsxrpsV6Ns445Mgz-vuE2kZUJ82RMT-8upQuMlUeI5cdALrEtrkNM2TEfHEBgr25kRN8qw-WwQ6Q3-m_2LjEMv1xwsg0ZyHCYyxh9aTBCRmZ_91NT0E8koKILy4mnfs8s-zhtzyBKoQfXau0D0Z3nJnp6qimWn9hpDM1pd6n2j6MCDlB599d0f84_ocBHDiw")
            .UseEasySvg()
            ;

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}