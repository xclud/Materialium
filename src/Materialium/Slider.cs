using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class Slider : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddAttribute(n++, "role", "slider");

            if (Disabled)
            {
                builder.AddAttribute(n++, "aria-disabled", "true");
            }

            builder.AddAttribute(n++, "aria-valuemin", Minimum.ToString());
            builder.AddAttribute(n++, "aria-valuemax", Maximum.ToString());
            builder.AddAttribute(n++, "aria-valuenow", Value.ToString());
            if (Step != null)
            {
                builder.AddAttribute(n++, "data-step", Step.Value.ToString());
            }

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] public bool Discrete { get; set; }
        [Parameter] public bool DisplayMarkers { get; set; }

        [Parameter] public bool Disabled { get; set; }

        [Parameter] public float Minimum { get; set; }
        [Parameter] public float Maximum { get; set; }
        [Parameter] public float Value { get; set; }
        [Parameter] public float? Step { get; set; }


        [JSInvokable]
        private void RaiseValueChanged(float value)
        {

        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.Slider;

            if (Discrete)
            {
                yield return Classes.Discrete;

                if (DisplayMarkers)
                {
                    yield return Classes.DisplayMarkers;
                }
            }
        }

        bool isFirstRender = true;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (isFirstRender && ComponentContext.IsConnected)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.slider.init", element, DotNetObjectRef.Create(this));
                isFirstRender = false;
            }
        }

        public static class Classes
        {
            public const string Slider = "mdc-slider";
            public const string Discrete = "mdc-slider--discrete";
            public const string DisplayMarkers = "mdc-slider--display-markers";
            public const string TrackContainer = "mdc-slider__track-container";
            public const string Track = "mdc-slider__track";
            public const string ThumbContainer = "mdc-slider__thumb-container";
            public const string Thumb = "mdc-slider__thumb";
            public const string Pin = "mdc-slider__pin";
            public const string PinValueMarker = "mdc-slider__pin-value-marker";
            public const string FocusRing = "mdc-slider__focus-ring";
        }
    }
}