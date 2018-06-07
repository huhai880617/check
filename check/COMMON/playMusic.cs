using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Media;

namespace check
{
    ///<summary>

    ///主要使用了Newtonsoft.Json使用了对象与Json字符串之间的互转

    ///</summary>

    public static class PlayMusic
    {
        public static void playDing()
        {
            SoundPlayer sp = new SoundPlayer(Properties.Resources.ding);
            sp.Play();
        }
        public static void playOpen()
        {
            SoundPlayer sp = new SoundPlayer(Properties.Resources.open);
            sp.Play();
        }
        public static void playError()
        {
            SoundPlayer sp = new SoundPlayer(Properties.Resources.error);
            sp.Play();
        }
        public static void playFinish()
        {
            SoundPlayer sp = new SoundPlayer(Properties.Resources.finish);
            sp.Play();
        }

    }
}
