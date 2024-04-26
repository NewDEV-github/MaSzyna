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

		/**
		 * The acceleration of the train.
		 */
		protected float Acceleration;

		/**
		 * Current pressure in the braking pipe.
		 * Measured in kPh.
		 */
		protected float BrakePipe = 0f;

		/**
		 * Current voltage taken by the train from the traction power line.
		 */
		protected float Current = 0f;

		/**
		 * Current speed of the train.
		 * Measured in km/h.
		 */
		protected int CurrentSpeed = 0;

		/**
		 * The deceleration of the train.
		 */
		protected float Deceleration = 0f;

		/**
		 * The current state of the doors on the left side of the train.
		 */
		protected Door DoorLeftOpen = Door.Locked;

		/**
		 * The current state of the doors on the right side of the train.
		 */
		protected Door DoorRightOpen = Door.Locked;

		/**
		 * Continuous power of the train.
		 * Measured in kW.
		 */
		protected int ContinuousPower = 0;

		/**
		 * Hourly power of the train.
		 * Measured in kW.
		 */
		protected int HourlyPower = 0;

		/**
		 * Has cabin indicator.
		 * true - the vehicle has a cabin and can be driven from it.
		 * false - the vehicle does not have a cabin, e.g. it's just a passenger train car.
		 */
		protected bool HasCab = false;

		/**
		 * Current cabin in which the player is currently located.
		 */
		protected CurrentCabin Cabin = CurrentCabin.NoCabin;

		/**
		 * Current state of the cabin A.
		 */
		protected CabinState CabinStateA = CabinState.NotActivated;

		/**
		 * Current state of the cabin B.
		 */
		protected CabinState CabinStateB = CabinState.NotActivated;

		/**
		 * Has engine indicator.
		 * true - the car has an engine under it's floor.
		 * false - the car does not have an engine under it's floor.
		 */
		protected bool HasEngine = false;

		/**
		 * Traction power of the train.
		 * Measured in kN.
		 */
		protected int TractionPower = 0;

		/**
		 * The current state of left light on the front of the train.
		 */
		protected Light LightFrontLeft = Light.Off;

		/**
		 * The current state of right light on the front of the train.
		 */
		protected Light LightFrontRight = Light.Off;

		/**
		 * The current state of top light on the front of the train.
		 */
		protected Light LightFrontTop = Light.Off;

		/**
		 * The current state of left light on the rear of the train.
		 */
		protected Light LightRearLeft = Light.Off;

		/**
		 * The current state of right light on the rear of the train.
		 */
		protected Light LightRearRight = Light.Off;

		/**
		 * The current state of top light on the rear of the train.
		 */
		protected Light LightRearTop = Light.Off;

		/**
		 * Current pressure in the main pipe.
		 */
		protected float CurrentMainPipe = 530f; //measured in kPh

		/**
		 * Maximum speed of the train.
		 * Measured in km/h.
		 */
		protected int MaxSpeed = 0;

		/**
		 * The current state of the pantograph A.
		 */
		protected Pantograph PantographAUp = Pantograph.Down;

		/**
		 * The current state of the pantograph B.
		 */
		protected Pantograph PantographBUp = Pantograph.Down;

		/**
		 * Ride direction of the train.
		 */
		protected Direction RideDirection = Direction.Neutral;

		/**
		 * The current state of the engine.
		 */
		protected Engine EngineState = Engine.StartElectric;

		/**
		 * The current state of the fan.
		 */
		protected bool StartedFan = false;

		/**
		 * Type of the train.
		 */
		protected Type TrainType = Type.DieselLoco;

		/**
		 * Weight of the train.
		 * Measured in tons.
		 */
		protected float Weight = 0f;

		/**
		 * Reduced weight of the train.
		 * Measured in tons.
		 */
		protected float ReducedWeight = 0f;

		/**
		 * Weight of sand in the train.
		 * Measured in kg.
		 */
		protected float SandWeight = 0f;

		/**
		 * Power that heating needs in order to work.
		 * Measured in kW.
		 */
		protected float HeatingPower = 0f;

		/**
		 * Power that lightning needs in order to work.
		 * Measured in kW.
		 */
		protected float LightningPower = 0f;

		/**
		 * Width of the train.
		 * Measured in meters.
		 */
		protected float Width = 0f;

		/**
		 * Height of the train.
		 * Measured in meters.
		 */
		protected float Height = 0f;

		/**
		 * Length of the train.
		 * Measured in meters.
		 */
		protected float Length = 0f;

		/**
		 * Frontal aerodynamic drag factor
		 */
		protected float AerodynamicDragFactor = 0f;

		/**
		 * Floor height above rail head for positioning universal loads.
		 * Measured in meters.
		 */
		protected float RailAndFloorDistance = 0f;

		/**
		 * Diameter of drive wheels.
		 * Measured in meters.
		 */
		protected float WheelDiameter = 0f;

		/**
		 * Moment of inertia of wheels.
		 * Measured in kg*m^2.
		 */
		protected float WheelInertiaMoment = 0f;

		/**
		 * Rail spacing.
		 * Measured in mm.
		 */
		protected int RailSpacing = 1455;

		/**
		 * Axle system.
		 */
		protected AxleType AxleSystem = AxleType.BoBo;

		/**
		 * Wheelbase of the boogie.
		 */
		protected AxleType BoogieWheelBase = AxleType.BoBo;

		/**
		 * The minimum radius of the curve through which a given vehicle can move.
		 * Measured in meters.
		 */
		protected float MinArcRadius = 0f;

		/**
		 * The type of bearings used in the vehicle
		 */
		protected BearingType Bearing = BearingType.Roll;

		/**
		 * Brake type used in the vehicle.
		 */
		protected Brake BrakeType = Brake.Hikg1;

		/**
		 * Number of friction elements per axle
		 */
		protected int FrictionElementsPerAxle = 0;

		/**
		 * Maximum braking force (mainly for simplified brakes).
		 * Measured in kPh.
		 */
		protected float MaxBrakeForce = 0f;

		/**
		 * The size of the ESt family distribution valve
		 */
		protected float EStSize = 0f;

		/**
		 * Braking force of a magnetic rail brake.
		 * Measured in kN.
		 */
		protected float MagneticBrakeForce = 0f;

		/**
		 * Maximum pressure in the brake cylinder.
		 * Measured in kPh.
		 */
		protected float MaxMainPipePressure = 0f;

		/**
		 * AntiSkid braking pressure.
		 * Measured in kPh.
		 */
		protected float AntiSlipperyBrakePressure = 0f;

		/**
		 * Number of brake cylinders.
		 * Measured in units
		 */
		protected int BrakeCylinders = 0;

		/**
		 * Maximum auxiliary brake pressure
		 * Measured in kPh
		 */
		protected float MaxAuxiliaryBrakePressure = 0f;

		/**
		 * Maximum brake pressure at "Tare" setting.
		 * Measured in kPh.
		 */
		protected float MaxTareBreakPressure = 0f;

		/**
		 * Maximum brake pressure in medium condition.
		 * Measured in kPh.
		 */
		protected float MaxMedBreakPressure = 0f;

		/**
		 * Brake cylinder diameter.
		 * Measured in meters.
		 */
		protected float BrakeCylinderDiameter = 0f;

		/**
		 * Stroke of the brake cylinder piston during braking.
		 * Measured in meters.
		 */
		protected float BrakeCylinderBrakingStroke = 0f;

		/**
		 * Pressure force of the brake cylinder return spring.
		 * Measured in kN.
		 */
		protected float BrakeCylinderSpringPressure = 0f;

		/**
		 * Pressure force of the piston stroke adjuster.
		 * Measured in kN.
		 */
		protected float StrokeAdjusterPressureForce = 0f;

		/**
		 * Efficiency of the brake gear while driving
		 */
		protected float BrakeGearDrivingEfficiency = 0f;

		/**
		 * Brake gear ratio from cylinder to all operated wheels - when constant
		 */
		protected float BrakeGearRatioFromCylToWheels = 0f;

		/**
		 * Brake gear ratio in empty condition
		 */
		protected float EmptyBrakeGearRatio = 0f;

		/**
		 * Brake gear ratio in loaded condition
		 */
		protected float LoadedBrakeGearRatio = 0f;

		/**
		 * Auxiliary tank capacity.
		 * Measured in liters.
		 */
		protected float AuxiliaryTankCapacity = 0f;

		/**
		 * Material type of the brake friction pair.
		 */
		protected BrakeFrictionMaterial BrakeFrictionMaterialType = BrakeFrictionMaterial.Cosid;

		/**
		 * Ratio of high pressure to low braking rate in Rapid mode
		 */
		protected float HighPressureToLowBrakeRapidModeRate = 0f;

		/**
		 * Rapid high braking switching speed.
		 * Measured in km/h.
		 */
		protected float RapidHighBrakingSwitchSpeed = 0f;

		/**
		 * Maximum working pressure in the main pipe
		 * Measured in kPh.
		 */
		protected float MaxMainPipeWorkingPressure = 0f;

		/**
		 * Minimal working pressure in the main pipe
		 * Measured in kPh.
		 */
		protected float MinMainPipeWorkingPressure = 0f;

		/**
		 * Vehicle main tank capacity.
		 * Measured in m^3.
		 */
		protected float MainTankCapacity = 0f;

		/**
		 * Minimal compressor pressure.
		 * When the compressor is driven by a diesel engine, when the maximum value is reached, the air is bleed to this value.
		 * Measured in kPh.
		 */
		protected float MinCompressorPressure = 0f;

		/**
		 * Maximum compressor pressure.
		 * When the compressor is driven by a diesel engine and this value is reached, the air is bleed to the minimal value..
		 * Measured in kPh.
		 */
		protected float MaxCompressorPressure = 0f;

		/**
		 * Compressor activation pressure when cabin no. 2 is active; providing this value causes the value given as the minimum to refer to active cabin no. 1
		 */
		protected float MinCompressorBPressure = 0f;

		/**
		 * Compressor activation pressure when cabin no. 2 is active; providing this value causes the value given as the maximum to refer to active cabin no. 1
		 */
		protected float MaxCompressorBPressure = 0f;

		/**
		 * Compressor speed.
		 * Measured in m^3/s.
		 */
		protected float CompressorSpeed = 0f;

		/**
		 * Compressor power source.
		 */
		protected CompressorPowerSources CompressorPowerSource = 0f;

		/**
		 * Behavior when the pressure in the main tank is exceeded when the compressor is driven by a diesel engine:
		 * false - the compressor pumps into the atmosphere, the tank slowly empties itself, after reaching the value specified as the minimum, the compressor pumps into the tank.
		 * true - the compressor completely fills the tank, the valve releases the pressure from the tank when it reaches the value specified as the maximum.
		 */
		protected bool CompressorTankValve = false;

		/**
		 * Air leak rate modifier from braking system components; standard speed = 1.0
		 */
		protected float AirLeakRateModifier = 0f;

		/**
		 * Opening pressure (higher) of the main tank safety valve.
		 * Measured in kPh.
		 */
		protected float MaxEvp = 0f;

		/**
		 * Closing pressure (lower) of the main tank safety valve.
		 * Measured in kPh.
		 */
		protected float MinEvp = 0f;

		/**
		 * Cross-section of the outlet of the main tank safety valve.
		 * Measured in liters/meter
		 */
		protected float OutletCrossSection = 0f;

		/**
		 * Possibility of filling the main line depends on the position of the travel switch:
		 * true - (default for combustion or combustion-electric vehicles!) - dependency
		 * false - (default for other traction vehicles!) - no dependency
		 */
		protected bool ReleaserPowerPosLock = false;

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

		protected enum CurrentCabin
		{
			NoCabin,
			CabinA,
			CabinB
		}

		//Enum, just in case there is more to add there
		protected enum CabinState
		{
			Activated,
			NotActivated
		}

		protected enum Light
		{
			White,
			Red,
			Off
		}

		protected enum BearingType
		{
			Roll,
			Slide
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

		protected enum AxleType
		{
			BoBo,
			CoCo,

			/**
			 * 2'2' wheel arrangement
			 */
			TwoTwo,

			/**
			 * 3'3' wheel arrangement
			 */
			ThreeThree
		}

		protected enum Brake
		{
			W,
			WLuVI,
			WLuL,
			WLuXR,
			K,
			Kg,
			Kp,
			Kss,
			Kkg,
			Kkp,
			Kks,
			Hikg1,
			Hikss,
			Hikp1,
			KE,
			SW,
			EStED,
			NESt3,
			ESt3,
			LSt,
			ESt4,
			ESt3AL2,
			EP1,
			EP2,
			M483,
			CV1LTR,
			CV1,
			CVR,
			Other
		}

		protected enum BrakeFrictionMaterial
		{
			P10Bg,
			P10Bgu,
			FR513,
			FR510,
			Cosid,
			P10yBg,
			P10yBgu,
			Disk1,
			Disk1Mg,
			Disk2
		}

		protected enum CompressorPowerSources
		{
			/**
			 * From the high voltage circuit - does not require a converter
			 */
			Main,

			/**
			 * Automatically - after turning on the converter
			 */
			Converter,

			/**
			 * Automatically - according to engine's work
			 */
			Engine,

			/**
			 * Powered by a converter in another vehicle from the side of coupler number 1
			 */
			Coupler1,

			/**
			 * Powered by a converter in another vehicle from the side of coupler number 2
			 */
			Coupler2
		}
	}
}