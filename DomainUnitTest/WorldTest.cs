using Domain.Model;
using Domain.Model.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DomainUnitTest
{
    public class WorldTest
    {
        [Fact]
        public void StartWorld()
        {
            int x = 1;
            int y = 2;
            World world = new World();
            Position finalPosition = new Position()
            {
                X = x,
                Y = y,
            };

            world.StartWorld(finalPosition);

            world.FinalPosition.X.Should().Be(x);
            world.FinalPosition.Y.Should().Be(y);
            world.ActualRobot.Should().BeNull();
            world.Scent.Should().BeEmpty();
        }
    }
}
