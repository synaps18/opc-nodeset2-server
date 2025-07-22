using DryIoc;
using Opc.NodeSet2.Server.Ioc;
using Opc.NodeSet2.Server.Server;
using Opc.NodeSet2.Server.Services;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Server;
using Container = DryIoc.Container;
using IContainer = DryIoc.IContainer;

namespace Opc.NodeSet2.Server
{
	/// <summary>
	///     Represents an application that initializes and starts a NodeSet2-based server.
	/// </summary>
	public class OpcNodeSet2Application
	{
		protected static readonly Container Container = new();
		protected readonly ApplicationInstance Application;

		/// <summary>
		///     Constructor
		/// </summary>
		public OpcNodeSet2Application()
		{
			Application = new ApplicationInstance
			{
				ApplicationName = "NodeSet2Server",
				ApplicationType = ApplicationType.Server,
				ConfigSectionName = "NodeSet2Server"
			};
		}

		/// <summary>
		///     Starts the application by initializing and registering required components, loading the application configuration,
		///     and starting the server and associated services.
		/// </summary>
		public async Task StartAsync()
		{
			RegisterTypesInternal(Container);

			var encodeableTypes = Container.Resolve<IEncodeableTypes>();
			RegisterEncodableTypes(encodeableTypes);

			var nodeSetFiles = Container.Resolve<INodeSetFiles>();
			RegisterNodeSet2Files(nodeSetFiles);

			var serviceContainer = Container.Resolve<INodeServiceContainer>();
			RegisterServicesInternal(serviceContainer);


			var server = Container.Resolve<IInternalStandardServer>();

			await Application.LoadApplicationConfiguration(false);
			await Application.CheckApplicationInstanceCertificates(false);
			await Application.Start(server as ServerBase);

			foreach (var service in Container.ResolveMany<INodeServiceBase>()) service.Start();
		}

		protected virtual void RegisterEncodableTypes(IEncodeableTypes encodeableTypes)
		{
			//Nothing to do here
		}

		protected virtual void RegisterNodeSet2Files(INodeSetFiles nodeSetFiles)
		{
			//Nothing to do here
		}

		protected virtual void RegisterServices(INodeServiceContainer nodeServiceContainer)
		{
			//Nothing to do here
		}

		private void RegisterServicesInternal(INodeServiceContainer nodeServiceContainer)
		{
			nodeServiceContainer.Register<ApplyMethodArguments>();
			RegisterServices(nodeServiceContainer);
		}

		protected virtual void RegisterTypes(IContainer container)
		{
			//Nothing to do here
		}

		private void RegisterTypesInternal(IContainer container)
		{
			container.Use(Application);
			container.Use(Application.ApplicationConfiguration);
			container.Register<IEncodeableTypes, EncodeableTypes>(new SingletonReuse());
			container.Register<INodeSetFiles, NodeSetFiles>(new SingletonReuse());
			container.Register<IInternalStandardServer, InternalStandardServer>(new SingletonReuse());
			container.Register<INodeManager, InternalNodeManager>(new SingletonReuse());
			container.Register<INodeServiceContainer, NodeServiceContainer>();

			RegisterTypes(container);
		}
	}
}