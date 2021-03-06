using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness += 12;
            robot.Energy -= 10;
        }
    }
}
