namespace ServiceLocator
{
    public class ServiceLocatorSceneBootstrapper : Bootstrapper
    {
        protected override void Bootstrap()
        {
            Container.ConfigureforScene();
        }
    }
}