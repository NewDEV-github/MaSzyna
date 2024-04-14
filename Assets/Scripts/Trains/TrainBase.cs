using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Trains
{
    /**
     * This class is the base class for all trains.
     * It contains all the common properties and methods that all trains have.
     * It is meant to be inherited by other classes.
     */
    public class TrainBase : MonoBehaviour
    {
        public EventReference speedEvent;
        private EventInstance _speedInstance;
        protected float Acceleration;
        protected float BrakePipe = 0f; //measured in kPh
        protected float Current = 0f;
        protected int CurrentSpeed = 0; //measured in km/h
        protected float Deceleration = 0f;
        protected Door DoorLeftOpen = Door.Locked;
        protected Door DoorRightOpen = Door.Locked;
        protected int EnginePower = 0; //measured in kW
        protected bool HasCab = false;
        protected Light LightFrontLeft = Light.Off;
        protected Light LightFrontRight = Light.Off;
        protected Light LightFrontTop = Light.Off;
        protected Light LightRearLeft = Light.Off;
        protected Light LightRearRight = Light.Off;
        protected Light LightRearTop = Light.Off;
        protected float MainPipe = 530f; //measured in kPh
        protected int MaxSpeed = 0; //measured in km/h
        protected Pantograph PantographAUp = Pantograph.Down;
        protected Pantograph PantographBUp = Pantograph.Down;
        protected Direction RideDirection = Direction.Neutral;
        protected Engine StartedEngine = Engine.StartElectric;
        protected bool StartedEngineGauge = false;
        protected bool StartedFan = false;
        protected Type TrainType = Type.DieselLoco;
        protected int Weight = 0; //measured in tons

        public TrainBase()
        {
            if (!speedEvent.IsNull) return;

            _speedInstance = RuntimeManager.CreateInstance(speedEvent);
        }

        public void Move()
        {
            // Move the train
        }

        public void SetAcceleration(float acceleration)
        {
            Acceleration = acceleration;
            _speedInstance.setParameterByName("Speed", acceleration);
            //@TODO: Set the speed based on weight and acceleration
            //@TODO: Set the current based on voltage and acceleration
        }

        protected enum Type
        {
            DieselLoco,
            ElectricLoco,
            HybridLoco,
            DieselMultipleUnit,
            ElectricMultipleUnit,
            HybridMultipleUnit
        }

        protected enum Light
        {
            White,
            Red,
            Off
        }

        protected enum Pantograph
        {
            Up,
            Down,
            Failure
        }

        protected enum Door
        {
            Open,
            Close,
            Locked
        }

        protected enum Engine
        {
            StartDiesel,
            StopDiesel,
            Failure,
            StartElectric,
            StopElectric
        }

        protected enum Direction
        {
            Backward,
            Neutral,
            Forward
        }
    }
}