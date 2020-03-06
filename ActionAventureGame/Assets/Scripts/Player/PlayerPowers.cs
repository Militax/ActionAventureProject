using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Power;


/// <summary>
/// Matis Duperray
/// 
/// Script qui attribue une direction et invoque le pouvoir du vent
/// </summary>
namespace Player
{
    public class PlayerPowers : MonoBehaviour
    {
        #region Variables
        public GameObject WindPowerPrefab;
        #region Invocation Points
        public Transform topPoint;
        public Transform downPoint;
        public Transform leftPoint;
        public Transform rightPoint;
        public Transform topLeftPoint;
        public Transform topRightPoint;
        public Transform downLeftPoint;
        public Transform downRightPoint;
        #endregion

        public string lookingAngle;
        #endregion

        void Update()
        {
            CalibrateWindPower();
            InstantiateWindWave();
        }

        #region Fonctions

        //Assigne la direction ou le vent partira
        void CalibrateWindPower()
        {
            float horizontalDelta;
            float verticalDelta;

            horizontalDelta = Input.GetAxisRaw("Horizontal");
            verticalDelta = Input.GetAxisRaw("Vertical");

            float angleShoot;
            

            //Vérification que l'input est volontaire
            if (verticalDelta > 0.2 || horizontalDelta > 0.2 || verticalDelta < -0.2 || horizontalDelta < -0.2)
            {
                #region Angles
                //On calcule l'angle en fonction du cos/sin des valeurs du joystick
                angleShoot = Mathf.Atan2(horizontalDelta, verticalDelta);

                if (angleShoot > (Mathf.PI/3) && angleShoot < ((2*Mathf.PI)/3))
                {//RIGHT

                    lookingAngle = ("RIGHT");
                }

                else if (angleShoot > -((2*Mathf.PI)/3) && angleShoot < -(Mathf.PI/3))
                {//LEFT

                    lookingAngle = ("LEFT");
                }

                else if (angleShoot > -(Mathf.PI/6) && angleShoot < (Mathf.PI/6))
                {//TOP

                    lookingAngle = ("TOP");
                }

                else if (angleShoot > ((2*Mathf.PI)/3) && angleShoot < ((5*Mathf.PI)/6))
                {//DOWN RIGHT

                    lookingAngle = ("DOWN RIGHT");
                }

                else if (angleShoot > (Mathf.PI/6) && angleShoot < (Mathf.PI/3))
                {//TOP RIGHT

                    lookingAngle = ("TOP RIGHT");
                }

                else if (angleShoot > -((5*Mathf.PI)/6) && angleShoot < -((2*Mathf.PI)/3))
                {//DOWN LEFT

                    lookingAngle = ("DOWN LEFT");
                }

                else if (angleShoot > -(Mathf.PI/3) && angleShoot < -(Mathf.PI/6))
                {//TOP LEFT

                    lookingAngle = ("TOP LEFT");
                }

                else
                {//DOWN

                    lookingAngle = ("DOWN");
                }
                #endregion
            }
        }

        //Créer la vague en fonction de la direction
        void InstantiateWindWave()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))//Clique droit
            {
                //Instantiation de la vague sur le bon point et dans la bonne direction en fonction du dernier angle enregistré par le joystick
                switch (lookingAngle)
                {
                    case ("TOP"):
                        GameObject WindWaveT = Instantiate(WindPowerPrefab, topPoint.position, topPoint.rotation);

                        WindWaveT.GetComponent<WindPower>().WaveDirection.y = 1;
                        break;

                    case ("DOWN"):
                        GameObject WindWaveD = Instantiate(WindPowerPrefab, downPoint.position, downPoint.rotation);

                        WindWaveD.GetComponent<WindPower>().WaveDirection.y = (-1);
                        break;

                    case ("LEFT"):
                        GameObject WindWaveL = Instantiate(WindPowerPrefab, leftPoint.position, leftPoint.rotation);

                        WindWaveL.GetComponent<WindPower>().WaveDirection.x = (-1);
                        break;

                    case ("RIGHT"):
                        GameObject WindWaveR = Instantiate(WindPowerPrefab, rightPoint.position, rightPoint.rotation);

                        WindWaveR.GetComponent<WindPower>().WaveDirection.x = 1;
                        break;

                    case ("TOP LEFT"):
                        GameObject WindWaveTL = Instantiate(WindPowerPrefab, topLeftPoint.position, topLeftPoint.rotation);

                        WindWaveTL.GetComponent<WindPower>().WaveDirection.x = (-1);
                        WindWaveTL.GetComponent<WindPower>().WaveDirection.y = 1;
                        break;

                    case ("TOP RIGHT"):
                        GameObject WindWaveTR = Instantiate(WindPowerPrefab, topRightPoint.position, topRightPoint.rotation);

                        WindWaveTR.GetComponent<WindPower>().WaveDirection.x = 1;
                        WindWaveTR.GetComponent<WindPower>().WaveDirection.y = 1;
                        break;

                    case ("DOWN LEFT"):
                        GameObject WindWaveDL = Instantiate(WindPowerPrefab, downLeftPoint.position, downLeftPoint.rotation);

                        WindWaveDL.GetComponent<WindPower>().WaveDirection.x = (-1);
                        WindWaveDL.GetComponent<WindPower>().WaveDirection.y = (-1);
                        break;

                    case ("DOWN RIGHT"):
                        GameObject WindWaveDR = Instantiate(WindPowerPrefab, downRightPoint.position, downRightPoint.rotation);

                        WindWaveDR.GetComponent<WindPower>().WaveDirection.x = 1;
                        WindWaveDR.GetComponent<WindPower>().WaveDirection.y = (-1);
                        break;
                }
            }
        }

        #endregion
    }
}