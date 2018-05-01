using System;
using System.IO;
using System.Linq;

namespace EnvTest
{
    class Program
    {
        static void Main()
        {
            string path;

            Console.WriteLine( "Special Folders:" );
            Console.WriteLine();

            var values = EnumHelper.GetValues<Environment.SpecialFolder>();
            foreach ( var item in values )
            {
                path = Environment.GetFolderPath( item );
                Console.WriteLine( "{0}: {1}", item, path );
            }
            Console.WriteLine();

            Console.WriteLine( "Environment Variables:" );
            Console.WriteLine();

            var envvalues = Environment.GetEnvironmentVariables();
            foreach ( var key in envvalues.Keys )
            {
                Console.WriteLine( "{0}: {1}", key, envvalues[key] );
            }
            Console.WriteLine();

            Console.WriteLine( "Temporary Path:" );
            Console.WriteLine();

            path = Path.GetTempPath();
            Console.WriteLine( path );
            Console.WriteLine();

            Console.WriteLine( "FileDataStore:" );
            Console.WriteLine();


            var ds = new FileDataStore( "EnvTest" );

            Console.WriteLine( "FolderPath = {0}", ds.FolderPath );
        }


    }

    public static class EnumHelper
    {
        public static TEnum[] GetValues<TEnum>()
#if CSHARP_7_3_UP
            where TEnum : System.Enum
#else
            where TEnum : struct
#endif
        {
            return Enum.GetValues( typeof( TEnum ) ).Cast<TEnum>().ToArray();
        }
    }

}
