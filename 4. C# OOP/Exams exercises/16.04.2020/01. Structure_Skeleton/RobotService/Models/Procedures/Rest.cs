using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness -= 3;
            robot.Energy += 10;
        }
    }
}
