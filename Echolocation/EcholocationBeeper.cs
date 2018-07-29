using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindFPS
{
    public class EcholocationBeeper
    {
        private SoundBackgroundBeeper soundBackgroundBeeper;

        public EcholocationBeeper(SoundBackgroundBeeper soundBackgroundBeeper)
        {
            this.soundBackgroundBeeper = soundBackgroundBeeper;
        }

        public void Beep(double distance, int columnId, int totalColumns)
        {
            byte left = this.GetLeftPanning(columnId, totalColumns);
            byte right = this.GetRightPanning(columnId, totalColumns);

            int frequency = (int)Math.Round(1000.0 / distance);

            this.soundBackgroundBeeper.Play(frequency, left, right);
        }

        private byte GetLeftPanning(int columnId, int totalColumns)
        {
            return (byte)Math.Min(255, Math.Max(0, (Math.Abs(0 - columnId) * 255 / totalColumns)));
        }

        private byte GetRightPanning(int columnId, int totalColumns)
        {
            return (byte)Math.Min(255, Math.Max(0, (Math.Abs(totalColumns - columnId) * 255 / totalColumns)));
        }
    }
}
