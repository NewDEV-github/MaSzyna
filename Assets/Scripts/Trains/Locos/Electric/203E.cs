namespace Trains.Locos.Electric
{
	public class _203E : TrainBase
	{
		public void Start()
		{
			TrainType = Type.ElectricLoco;
			MaxSpeed = 125;
			Acceleration = 2.5f;
			Deceleration = 5;
			Weight = 167f;
			EngineState = Engine.StartElectric;
			HourlyPower = 4160;
			ContinuousPower = 4000;
			TractionPower = 530;
			HasCab = true;
		}
	}
}