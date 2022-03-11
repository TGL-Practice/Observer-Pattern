/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TGLUtility.ObserverPattern
{
    /// <summary>
    /// Observer of an Observer patttern
    /// </summary>
    public class ObserverObj
    {
        private Transform _connectedToObj;
        private MaterialColorChanger _colorChanger;
        private DetectDirection _detectDirection;
        public ObserverObj(IObservedObj subjectObj)
		{
            subjectObj.stateOfHandlerChanged += Subject_StateChanged;
		}

		private void Subject_StateChanged(ObsPtrnStateDemo obj)
		{
            //Debug.Log("Ball is moving in (" + obj.currentGlobalDirection + ") direction with curr pos as (" + obj.currentGlobalPosition + ")", _connectedToObj);
            if(_detectDirection)
			{
                if (_colorChanger && ValidateDirectionInObserver(obj.currentGlobalDirection))
                {
                    _colorChanger.ActivateMtl();
                }
                else
				{
                    _colorChanger.DeactivateMtl();
                }
            }
		}
        
        public void SetConnectedGameObject(Transform connectedObj)
		{
            _connectedToObj = connectedObj;
            _colorChanger = connectedObj.GetComponent<MaterialColorChanger>();
            _detectDirection = connectedObj.GetComponent<DetectDirection>();
            if (_colorChanger) 
            {
                _colorChanger.ValidateData();
            }

        }

        private bool ValidateDirectionInObserver(Vector3 currDir)
		{
			bool returnBool = false;
            if (_detectDirection.detectionAxis != DirectionEnums.NONE)
            {
                switch(_detectDirection.detectionAxis)
				{
					case DirectionEnums.POSITIVE_X_AXIS:
						returnBool = currDir.x >= 0;
						break;
                    case DirectionEnums.NEGATIVE_X_AXIS:
						returnBool = currDir.x < 0;
						break;
					case DirectionEnums.POSITIVE_Z_AXIS:
						returnBool = currDir.z >= 0;
						break;
					case DirectionEnums.NEGATIVE_Z_AXIS:
						returnBool = currDir.z < 0;
						break;
                    default:
                        returnBool = false;
                        break;
				}
            }
            else
			{
                returnBool = false;
			}

            return returnBool;

        }

    }
}