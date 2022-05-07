using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace libs
{
    class App
    {

        static void Main(string[] args)
        {
            /*
                TODO:

                        Change the menu item appearance by changing just the minimum number of items
                        directly in place by using CursorPosition-ing

                        In turn we should get rid of the flickering by redrawing all of the items (propmt, title, options),
                        simultaneously beeing smoother and faster

                        An improved 'DisplayMenuOptions()' should do the job

                        Bug found: 'Exit' seems to have a problem by switching first into the hash-menu, then 'Exit'-ing
                        and then trying 'Exit'-ing the main-menu (= have to tap twice the Enter-key! Buffers or what? Idk... yet.)
            */

            Test.Run_Menu_Test();
        }

    }
}
