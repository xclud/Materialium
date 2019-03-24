namespace Materialium
{
    public static class Classes
    {
        public static class Button
        {
            public const string Base = "mdc-button";
            public const string Raised = "mdc-button--raised";
            public const string Unelevated = "mdc-button--unelevated";
            public const string Outlined = "mdc-button--outlined";
            public const string Dense = "mdc-button--dense";
            public const string ButtonLabel = "mdc-button__label";
            public const string ButtonIcon = "mdc-button__icon";
        }

        public static class Tab
        {
            /// <summary>
            /// Mandatory.
            /// </summary>
            public const string Base = "mdc-tab";

            /// <summary>
            /// Optional. Indicates that the tab is active.
            /// </summary>
            public const string Active = "mdc-tab--active";

            /// <summary>
            /// Optional. Indicates that the tab icon and label should flow vertically instead of horizontally.
            /// </summary>
            public const string Stacked = "mdc-tab--stacked";

            /// <summary>
            /// Optional. Indicates that the tab should shrink in size to be as narrow as possible without causing text to wrap.
            /// </summary>
            public const string MinWidth = "mdc-tab--min-width";

            /// <summary>
            /// Mandatory. Denotes the ripple surface for the tab.
            /// </summary>
            public const string Ripple = "mdc-tab__ripple";

            /// <summary>
            /// Mandatory. Indicates the text label of the tab.
            /// </summary>
            public const string Content = "mdc-tab__content";

            /// <summary>
            /// Optional. Indicates a leading icon in the tab.
            /// </summary>
            public const string Icon = "mdc-tab__icon";

            /// <summary>
            /// Optional. Indicates an icon in the tab.
            /// </summary>
            public const string TextLabel = "mdc-tab__text-label";
        }

        public static class TabIndicator
        {
            /// <summary>
            /// Mandatory. Contains the tab indicator content.
            /// </summary>
            public const string Base = "mdc-tab-indicator";

            /// <summary>
            /// Mandatory. Denotes the tab indicator content.
            /// </summary>
            public const string Content = "mdc-tab-indicator__content";

            /// <summary>
            /// Optional. Visually activates the indicator.
            /// </summary>
            public const string Active = "mdc-tab-indicator--active";

            /// <summary>
            /// Optional. Sets up the tab indicator to fade in on activation and fade out on deactivation.
            /// </summary>
            public const string Fade = "mdc-tab-indicator--fade";

            /// <summary>
            /// Optional. Denotes an underline tab indicator.
            /// </summary>
            /// <remarks>
            /// Exactly one of the --underline or --icon content modifier classes should be present.
            /// </remarks>
            public const string ContentUnderline = "mdc-tab-indicator__content--underline";

            /// <summary>
            /// Optional. Denotes an icon tab indicator.
            /// </summary>
            /// <remarks>
            /// Exactly one of the --underline or --icon content modifier classes should be present.
            /// </remarks>
            public const string ContentIcon = "mdc-tab-indicator__content--icon";
        }

        public static class TabBar
        {
            public const string Base = "mdc-tab-bar";
        }

        public static class TabScroller
        {
            public const string Base = "mdc-tab-scroller";
            public const string AlignStart = "mdc-tab-scroller--align-start";
            public const string AlignEnd = "mdc-tab-scroller--align-end";
            public const string AlignCenter = "mdc-tab-scroller--align-center";
            public const string ScrollArea = "mdc-tab-scroller__scroll-area";
            public const string ScrollContent = "mdc-tab-scroller__scroll-content";
        }

        public static class ImageList
        {
            /// <summary>
            /// Mandatory. Indicates the root Image List element.
            /// </summary>
            public const string Base = "mdc-image-list";

            /// <summary>
            /// Optional. Indicates that this Image List should use the Masonry variant.
            /// </summary>
            public const string Masonry = "mdc-image-list--masonry";

            /// <summary>
            /// Optional. Indicates that supporting content should be positioned in a scrim overlaying each image (instead of positioned separately under each image).
            /// </summary>
            public const string WithTextProtection = "mdc-image-list--with-text-protection";

            /// <summary>
            /// Mandatory. Indicates each item in an Image List.
            /// </summary>
            public const string Item = "mdc-image-list__item";

            /// <summary>
            /// Optional. Parent of each item's image element, responsible for constraining aspect ratio. This element may be omitted entirely if images are already sized to the correct aspect ratio.
            /// </summary>
            public const string ImageAspectContainer = "mdc-image-list__image-aspect-container";

            /// <summary>
            /// Mandatory. Indicates the image element in each item.
            /// </summary>
            public const string Image = "mdc-image-list__image";

            /// <summary>
            /// Optional. Indicates the area within each item containing the supporting text label, if the Image List contains text labels.
            /// </summary>
            public const string Supporting = "mdc-image-list__supporting";

            /// <summary>
            /// Optional. Indicates the text label in each item, if the Image List contains text labels.
            /// </summary>
            public const string Label = "mdc-image-list__label";
        }
    }
}