using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Common
{
    public class ScoreCalculator
    {
        public int QueueValue { get; set; }
        public string RiskValue { get; set; }

        public int Calculate(int positionScore, int experienceScore, int sectorScore)
        {

            float ws = 0.35F;
            float wp = 0.55F;
            float we = 0.2F;

            float creditScore = ws * sectorScore + wp * positionScore - experienceScore * we;

            if (creditScore >= 80)
            {
                RiskValue = "Düşük Risk";
                if (creditScore >= 90)
                    QueueValue = 1;
                else
                    QueueValue = 2;
            }
            else if (creditScore >= 60)
            {
                RiskValue = "Orta Risk";
                if (creditScore >= 70)
                    QueueValue = 3;
                else
                    QueueValue = 4;
            }
            else
            {
                RiskValue = "Yüksek Risk";
                QueueValue = 5;
            }

            return (int)creditScore;
        }
    }
}
