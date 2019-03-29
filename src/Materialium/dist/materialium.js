var _nextId = 0;
var _registery = {};

function _save(obj) {
    _registery[_nextId + ''] = obj;
    return _nextId++;
}
function _find(id) {
    return _registery[id + ''];
}

function _allowDrop(event) {
    event.preventDefault();
}

window.Materialium = {
    button: {
        init: function (elem) {
            mdc.ripple.MDCRipple.attachTo(elem);
        }
    },

    drawer: {
        init: function (elem) {
            const drawer = mdc.drawer.MDCDrawer.attachTo(elem);
            return _save(drawer);
        }
    },

    topAppBar: {
        init: function (elem, scrollTarget) {
            const topAppBar = mdc.topAppBar.MDCTopAppBar.attachTo(elem);
            if (scrollTarget) {
                topAppBar.setScrollTarget(document.querySelector(scrollTarget));
            }

            return _save(topAppBar);
        },
        nav: function (topAppBarSelector, drawerSelector) {
            const drawerEl = document.querySelector(drawerSelector);
            const topAppBarEl = document.querySelector(topAppBarSelector);

            const topAppBar = mdc.topAppBar.MDCTopAppBar.attachTo(topAppBarEl);
            const drawer = mdc.drawer.MDCDrawer.attachTo(drawerEl);

            topAppBar.listen('MDCTopAppBar:nav', () => {
                drawer.open = !drawer.open;
            });
        }
    },
    dialog: {
        init: function (elem) {
            const dialog = mdc.dialog.MDCDialog.attachTo(elem);
            return _save(dialog);
        },
        show: function (id) {
            const dialog = _find(id);

            var promise = new Promise(function (resolve, reject) {
                dialog.listen('MDCDialog:closed', function (event) {
                    resolve(event.detail.action);
                });

                dialog.open();
            });

            return promise;
        },
        close: function (id, action) {
            const dialog = _find(id);
            dialog.close(action);
        },
        layout: function (id) {
            const dialog = _find(id);
            dialog.layout();
        }
    },
    tabBar: {
        init: function (elem) {
            mdc.tabBar.MDCTabBar.attachTo(elem);
        }
    },
    notchedOutline: {
        init: function (elem) {
            mdc.notchedOutline.MDCNotchedOutline.attachTo(elem);
        }
    },
    select: {
        init: function (elem) {
            mdc.select.MDCSelect.attachTo(elem);
        }
    },
    dataTable: {
        init: function (elem) {
            const tmp = new MDCDataTable(elem);
        }
    },

    textField: {
        init: function (elem) {
            mdc.textField.MDCTextField.attachTo(elem);
        }
    },

    switch: {
        setChecked: function (elem, isChecked) {
            const switchControl = mdc.switchControl.MDCSwitch.attachTo(elem);
            switchControl.checked = isChecked;
        }
    },
    draganddrop: {
        allowDrop: function (elem) {
            elem.addEventListener('dragover', _allowDrop);
        }
    },
    dateTime: {
        getTimezoneOffset: function () {
            var dt = new Date();
            return dt.getTimezoneOffset();
        }
    },
    autoInit: function () {
        mdc.autoInit();
    }
};
