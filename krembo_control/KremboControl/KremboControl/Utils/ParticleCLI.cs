using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KremboControl.Utils
{
    class ParticleCLI
    {
        private static Process startNewCmd()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();
            return cmd;
        }

        public static void flashPhoton(Photon photon, string bin_file_path)
        {

            Process cmd = startNewCmd();

            cmd.StandardInput.WriteLine(@"cd " + bin_file_path);
            cmd.StandardInput.WriteLine("particle flash " + photon.id + " firmware.bin");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();

            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();
            cmd.WaitForExit();
            // string output = cmd.StandardOutput.ReadToEnd();
            //  Console.WriteLine("hello" + output);

        }

        public static void flashPhotons(List<Photon> photons_list, string bin_file_path)
        {           
            Parallel.ForEach(photons_list, photon =>
            {
                flashPhoton(photon, bin_file_path);
            });
        }

        public static List<Photon> getOnlinePhotons()
        {
            Process cmd = startNewCmd();
            cmd.StandardInput.WriteLine("particle list");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();

           // cmd.BeginOutputReadLine();
          //  cmd.BeginErrorReadLine();
            cmd.WaitForExit();

            string output = cmd.StandardOutput.ReadToEnd();
            Console.WriteLine("hello" + output);

            return null;
        }
    }
}
