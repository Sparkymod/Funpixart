﻿using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Funpixart.Data.Handlers
{
    public class TrackingCircuitHandler : CircuitHandler
    {
        private readonly List<Circuit> Circuits = new();

        public override Task OnConnectionUpAsync(Circuit circuit,
            CancellationToken cancellationToken)
        {
            Circuits.Add(circuit);
            return Task.CompletedTask;
        }

        public override Task OnConnectionDownAsync(Circuit circuit,
            CancellationToken cancellationToken)
        {
            Circuits.Remove(circuit);
            return Task.CompletedTask;
        }

        public int ConnectedCircuits => Circuits.Count;
    }
}