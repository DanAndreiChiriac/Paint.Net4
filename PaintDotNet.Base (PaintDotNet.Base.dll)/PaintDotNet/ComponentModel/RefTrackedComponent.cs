namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;
    using System.ComponentModel;

    public abstract class RefTrackedComponent : RefTrackedObject, IComponent, IDisposable
    {
        private static readonly object eventDisposedKey = new object();
        private EventHandlerList events;
        private ISite site;

        public event EventHandler Disposed
        {
            add
            {
                this.Events.AddHandler(eventDisposedKey, value);
            }
            remove
            {
                this.Events.RemoveHandler(eventDisposedKey, value);
            }
        }

        protected RefTrackedComponent()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                object sync = base.Sync;
                lock (sync)
                {
                    if ((this.site != null) && (this.site.Container != null))
                    {
                        this.site.Container.Remove(this);
                    }
                    if (this.events != null)
                    {
                        ((EventHandler) this.events[eventDisposedKey]).Raise(this);
                    }
                }
            }
            DisposableUtil.Free<EventHandlerList>(ref this.events, disposing);
            base.Dispose(disposing);
        }

        protected virtual object GetService(Type service)
        {
            ISite site = this.Site;
            if (site != null)
            {
                return site.GetService(service);
            }
            return null;
        }

        protected virtual void OnSiteChanged(ISite oldSite, ISite newSite)
        {
        }

        public override string ToString()
        {
            ISite site = this.site;
            if (site != null)
            {
                return (site.Name + " [" + base.GetType().FullName + "]");
            }
            return base.GetType().FullName;
        }

        protected EventHandlerList Events
        {
            get
            {
                object sync = base.Sync;
                lock (sync)
                {
                    if (this.events == null)
                    {
                        this.events = new EventHandlerList();
                    }
                    return this.events;
                }
            }
        }

        public ISite Site
        {
            get => 
                this.site;
            set
            {
                ISite oldSite = this.site;
                this.site = value;
                this.OnSiteChanged(oldSite, value);
            }
        }
    }
}

