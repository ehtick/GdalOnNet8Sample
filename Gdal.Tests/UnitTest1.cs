using GdalNetCore.Core;

namespace Gdal.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var kit = new GdalKit();
        var info = kit.GetGdalInfo();
        Assert.That(info.ReleaseName == "3.11.3");
        Console.WriteLine("OS: " + Environment.OSVersion.Platform);
        Console.WriteLine("Gdal drivers: " + info.GdalDrivers.Count);
        info.GdalDrivers.Sort();
        Console.WriteLine("GDAL Drivers: " + String.Join(',', info.GdalDrivers));

        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            Assert.That(info.GdalDrivers.Count == 142);
        }
        else { 
            Assert.That(info.GdalDrivers.Count == 143);
        }

        Console.WriteLine("OGR Drivers: " + String.Join(',', info.OgrDrivers));
        Console.WriteLine("Ogr drivers: " + info.OgrDrivers.Count);
        Assert.That(info.OgrDrivers.Count == 79);
    }
}