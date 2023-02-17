using System;
using System.Collections.Generic;
using System.Linq;
using Code.Attributes.Injection;
using Code.Extensions;
using UnityEngine;
using Zenject;

namespace Code.Registration.Installers.Scene
{
    public class ViewsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            foreach (var injectable in FindInjectableViews())
                Container.BindInstance(injectable);
        }

        private IEnumerable<object> FindInjectableViews() =>
            FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID)
                .Where(x => x.HaveCustomAttribute<ImplicitInjectableViewAttribute>());

    }
}