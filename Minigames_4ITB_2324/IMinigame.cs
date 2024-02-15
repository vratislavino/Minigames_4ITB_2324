using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minigames_4ITB_2324
{
    public interface IMinigame
    {
        int Score { get; set; }

        event Action<int> MinigameEnded;

        void StartMinigame();
    }
}
