using NAudio.Wave;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public static class SoundPlayer
    {
        public static void PlaySound(string soundName)
        {
            if (soundName != "")
            {
                var mp3File = Path.Combine(ApplicationInfo.ApplicationPath, $"Sounds\\{soundName}.mp3");
                var reader = new Mp3FileReader(mp3File);
                var waveOut = new WaveOut();
                waveOut.Init(reader);
                waveOut.Play();
            }
        }
    }
}
