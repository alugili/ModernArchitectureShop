**Prerequisites**

.NET Core 5 preview (Last)

Docker for desktop

[Install Dapr
0.9](https://github.com/dapr/docs/blob/master/getting-started/environment-setup.md#installing-dapr-cli)

[Install Tye
0.4](https://github.com/dotnet/tye/blob/master/docs/getting_started.md)
// Some stuff are still here in state Todo

**Getting Started**

By running this mode, we use Tye as docker-compose to start the
infrastructure, i.e., seq and SQL Server.

The first step you have to install the Prerequisites

1)  In Console execute: tye run tye-min.yaml

There are two options to start services:

1)  Starts Services from Visual Studio 2019 preview (latest version)

2)  Open the solution and press F5.

**- Or -**

Starts Services with Dapr

Then, all services will be started by the PowerShell with Dapr.

1\) Execute the PowerShell script: dapr_start.ps1
