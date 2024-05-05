namespace Trains.Locos.Electric
{
	public class _4E : TrainBase
	{
		public void Start()
		{
			TrainType = Type.ElectricLoco;
			MaxSpeed = 125;
			Acceleration = 2.5f;
			Deceleration = 5;
			Weight = 80f;
			EngineState = Engine.StartElectric;
			HourlyPower = 2000;
			ContinuousPower = 2080;
			TractionPower = 530;
			HasCab = true;
		}
	}
}