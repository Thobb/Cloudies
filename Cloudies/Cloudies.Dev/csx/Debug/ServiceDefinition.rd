<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Cloudies.Dev" generation="1" functional="0" release="0" Id="2cfd33d6-023a-495e-aa1e-b11fd50c5b0a" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Cloudies.DevGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Cloudies.Web:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Cloudies.Dev/Cloudies.DevGroup/LB:Cloudies.Web:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Cloudies.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Cloudies.Dev/Cloudies.DevGroup/MapCloudies.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="Cloudies.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Cloudies.Dev/Cloudies.DevGroup/MapCloudies.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Cloudies.Web:Endpoint1">
          <toPorts>
            <inPortMoniker name="/Cloudies.Dev/Cloudies.DevGroup/Cloudies.Web/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapCloudies.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Cloudies.Dev/Cloudies.DevGroup/Cloudies.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapCloudies.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Cloudies.Dev/Cloudies.DevGroup/Cloudies.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Cloudies.Web" generation="1" functional="0" release="0" software="D:\NeerajVerma\Cloudies\Cloudies.Dev\csx\Debug\roles\Cloudies.Web" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Cloudies.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Cloudies.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Cloudies.Dev/Cloudies.DevGroup/Cloudies.WebInstances" />
            <sCSPolicyUpdateDomainMoniker name="/Cloudies.Dev/Cloudies.DevGroup/Cloudies.WebUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/Cloudies.Dev/Cloudies.DevGroup/Cloudies.WebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="Cloudies.WebUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="Cloudies.WebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="Cloudies.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="340f42ac-83a0-43a9-beeb-4bb17d778d1e" ref="Microsoft.RedDog.Contract\ServiceContract\Cloudies.DevContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="60468bbd-34ad-46a3-945e-c74d747f93ef" ref="Microsoft.RedDog.Contract\Interface\Cloudies.Web:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Cloudies.Dev/Cloudies.DevGroup/Cloudies.Web:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>