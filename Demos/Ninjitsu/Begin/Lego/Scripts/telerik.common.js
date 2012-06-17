(function($) {
    // fix background flickering under IE6
    try {
        if (document.execCommand)
            document.execCommand('BackgroundImageCache', false, true);
    } catch (e) { }

    // Patching jQuery to correctly support mouseenter/mouseleave. Remove once fixed.

    function liveConvert(type, selector) {
        return ["live", type, selector.replace(/\./g, "`").replace(/ /g, "&")].join(".");
    }

    function isBogus(element) {
        try {
            var parent = element.parentNode;
            return false;
        } catch (error) {
            return true;
        }
    }

    var routedLiveEvents = {
        mouseenter: 'mouseover',
        mouseleave: 'mouseout'
    };

    $.fn.extend({

        live: function(type, data, fn) {
            var bubble;

            if ($.isFunction(data)) {
                bubble = fn;
                fn = data;
                data = undefined;
            }

            var proxy = $.proxy(fn);

            if (routedLiveEvents[type]) {
                type = routedLiveEvents[type];
                proxy = $.proxy(fn, function(e) {
                    if (!isBogus(e.relatedTarget)) {
                        if (this !== e.relatedTarget && !$.contains(this, e.relatedTarget))
                            fn.apply(this, arguments);

                        if (bubble)
                            $(this.parentNode).trigger(e);
                    }
                });
            }

            $(this.context).bind(liveConvert(type, this.selector), {
                data: data, selector: this.selector, live: type
            }, proxy);

            return this;
        },

        die: function(type, fn) {
            if (routedLiveEvents[type])
                type = routedLiveEvents[type];

            jQuery(this.context).unbind(liveConvert(type, this.selector), fn ? { guid: fn.guid + this.selector + type} : null);
            return this;
        }
    });

    $.telerik = {

        bind: function(context, handler) {
            return function() {
                handler.apply(context, arguments);
            };
        },

        toJson: function(o) {
            var result = [];
            for (var key in o) {
                var value = o[key];
                if (typeof value != 'object')
                    result.push('"' + key + '":"' + value + '"');
                else
                    result.push('"' + key + '":' + this.toJson(value));
            }
            return '{' + result.join(',') + '}';
        },

        bindToJavscriptAction: function(context, handler) {
            return function(e) {
                if (e && e.preventDefault)
                    e.preventDefault();

                handler.apply(context, [e, this]);
            };
        },

        delegate: function(context, handler) {
            return function(e) {
                handler.apply(context, [e, this]);
            };
        },

        preventDefault: function(e) {
            e.preventDefault();
        },

        hover: function() {
            $(this).addClass('t-state-hover');
        },

        leave: function() {
            $(this).removeClass('t-state-hover');
        },

        buttonHover: function() {
            $(this).addClass('t-button-hover');
        },

        buttonLeave: function() {
            $(this).removeClass('t-button-hover');
        },

        preventDefault: function(e) {
            e.preventDefault();
        },

        stringBuilder: function() {
            this.buffer = [];
        },

        ajaxError: function(element, eventName, xhr, status) {
            var prevented = this.trigger(element, eventName,
                {
                    XMLHttpRequest: xhr,
                    textStatus: status
                });

            if (!prevented) {
                if (status == 'error' && xhr.status != '0')
                    alert('Error! The requested URL returned ' + xhr.status + ' - ' + xhr.statusText);
                if (status == 'timeout')
                    alert('Error! Server timeout.');
            }
        },

        trigger: function(element, eventName, options) {
            var e = new $.Event(eventName);
            $.extend(e, options);
            e.stopPropagation();
            $(element).trigger(e);
            return e.isDefaultPrevented();
        },

        // Returns the type as a string. Not full. Used in string formatting
        getType: function(obj) {
            if (obj instanceof Date)
                return 'date';
            return 'object';
        },

        formatString: function() {
            var s = arguments[0];

            for (var i = 0, l = arguments.length - 1; i < l; i++) {
                var reg = new RegExp('\\{' + i + '(:([^\\}]+))?\\}', 'gm');

                var argument = arguments[i + 1];

                var formatter = this.formatters[this.getType(argument)];
                if (formatter) {
                    var match = reg.exec(s);
                    argument = formatter(argument, match[2]);
                }
                s = s.replace(reg, argument);
            }
            return s;
        },

        formatters: {},

        fx: {},

        cultureInfo: {}
    };

    $.telerik.datetime = function() {
        if (arguments.length == 0)
            this.value = new Date();
        else if (arguments.length == 1)
            this.value = new Date(arguments[0]);
        else if (arguments.length == 3)
            this.value = new Date(arguments[0], arguments[1], arguments[2]);
        else if (arguments.length == 6)
            this.value = new Date(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4], arguments[5]);
        else
            this.value = new Date(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4], arguments[5], arguments[6]);

        return this;
    }

    $.extend($.telerik.datetime, {
        msPerMinute: 60000,
        msPerDay: 86400000,
        add: function(date, valueToAdd) {
            var tzOffsetBefore = date.timeOffset();
            var resultDate = new $.telerik.datetime(date.time() + valueToAdd);
            var tzOffsetDiff = resultDate.timeOffset() - tzOffsetBefore;
            return new $.telerik.datetime(resultDate.time() + tzOffsetDiff * $.telerik.datetime.msPerMinute);
        },

        subtract: function(date, dateToSubtract) {
            dateToSubtract = new $.telerik.datetime(dateToSubtract).toDate();
            var diff = date.time() - dateToSubtract;
            var tzOffsetDiff = date.timeOffset() - dateToSubtract.timeOffset();
            return diff - (tzOffsetDiff * $.telerik.datetime.msPerMinute);
        },

        firstDayOfMonth: function(date) {
            return new $.telerik.datetime(0)
                        .hours(0)
                        .minutes(0)
                        .year(date.year(), date.month(), 1);
        },

        firstVisibleDay: function(date) {
            var firstVisibleDay = new $.telerik.datetime(date.year(), date.month(), 0);
            while (firstVisibleDay.day() != 0) {
                $.telerik.datetime.modify(firstVisibleDay, -1 * $.telerik.datetime.msPerDay)
            }
            return firstVisibleDay;
        },

        modify: function(date, value) {
            var tzOffsetBefore = date.timeOffset();
            var resultDate = new $.telerik.datetime(date.time() + value);
            var tzOffsetDiff = resultDate.timeOffset() - tzOffsetBefore;
            date.time(resultDate.time() + tzOffsetDiff * $.telerik.datetime.msPerMinute);
        }
    });

    $.telerik.datetime.prototype = {

        year: function() {
            if (arguments.length == 0)
                return this.value.getFullYear();
            else if (arguments.length == 1)
                this.value.setFullYear(arguments[0]);
            else
                this.value.setFullYear(arguments[0], arguments[1], arguments[2]);

            return this;
        },

        timeOffset: function() {
            return this.value.getTimezoneOffset();
        },

        day: function() {
            return this.value.getDay();
        },

        toDate: function() {
            return this.value;
        },

        addMonth: function(value) {
            this.month(this.month() + value);
        },

        addYear: function(value) {
            this.year(this.year() + value);
        }
    };
    
    $.each(["Month", "Date", "Hours", "Minutes", "Seconds", "Milliseconds", "Time"], function(index, timeComponent) {
        $.telerik.datetime.prototype[timeComponent.toLowerCase()] = 
            function() {
                if (arguments.length == 1)
                    this.value["set" + timeComponent](arguments[0]);
                else
                    return this.value["get" + timeComponent]();

                return this;
            };
    });

    $.telerik.stringBuilder.prototype = {

        cat: function(what) {
            this.buffer.push(what);
            return this;
        },

        rep: function(what, howManyTimes) {
            for (var i = 0; i < howManyTimes; i++)
                this.cat(what);
            return this;
        },

        catIf: function(what, condition) {
            if (condition)
                this.cat(what);
            return this;
        },

        string: function() {
            return this.buffer.join('');
        }
    }

    // Effects ($.telerik.fx)

    var prepareAnimations = function(effects, target, end) {
        if (target.length == 0 && end) {
            end();
            return null;
        }

        var animationsToPlay = effects.length;

        return function() {
            if (--animationsToPlay == 0 && end)
                end();
        };
    };

    $.extend($.telerik.fx, {
        _wrap: function(element) {
            if (!element.parent().hasClass('t-animation-container')) {
                element.wrap(
							 $('<div/>')
							 .addClass('t-animation-container')
							 .css({
							     width: element.outerWidth(),
							     height: element.outerHeight()
							 }));
            }

            return element.parent();
        },

        play: function(effects, target, options, end) {
            var afterAnimation = prepareAnimations(effects, target, end);

            if (afterAnimation === null) return;

            target.stop(false, true);

            for (var i = 0, len = effects.length; i < len; i++) {

                var effect = new $.telerik.fx[effects[i].name](target);

                if (!target.data('effect-' + i)) {
                    effect.play($.extend(effects[i], options), afterAnimation);

                    target.data('effect-' + i, effect);
                }
            }
        },

        rewind: function(effects, target, options, end) {
            var afterAnimation = prepareAnimations(effects, target, end);

            if (afterAnimation === null) return;

            for (var i = effects.length - 1; i >= 0; i--) {

                var effect = target.data('effect-' + i) || new $.telerik.fx[effects[i].name](target);

                effect.rewind($.extend(effects[i], options), afterAnimation);

                target.data('effect-' + i, null);
            }
        }
    });

    // simple show/hide toggle

    $.telerik.fx.toggle = function(element) {
        this.element = element.stop(false, true);
    };

    $.extend($.telerik.fx.toggle.prototype, {
        play: function(options, end) {
            this.element.show();
            if (end) end();
        },
        rewind: function(options, end) {
            this.element.hide();
            if (end) end();
        }
    });

    $.telerik.fx.toggle.defaults = function() {
        return { name: 'toggle' };
    };

    // slide animation

    $.telerik.fx.slide = function(element) {
        this.element = element;

        this.animationContainer = $.telerik.fx._wrap(element);
    };

    $.extend($.telerik.fx.slide.prototype, {
        play: function(options, end) {

            var animationContainer = this.animationContainer;

            this.element.css('display', 'block').stop();

            animationContainer
				.css({
				    display: 'block',
				    overflow: 'hidden'
				});

            var width = this.element.outerWidth();
            var height = this.element.outerHeight();
            var animatedProperty = options.direction == 'bottom' ? 'marginTop' : 'marginLeft';
            var animatedStartValue = options.direction == 'bottom' ? -height : -width;

            animationContainer
				.css({
				    width: width,
				    height: height
				});

            var animationEnd = {};
            animationEnd[animatedProperty] = 0;

            this.element
                .css('width', this.element.width())
                .each(function() { this.style.cssText = this.style.cssText; })
                .css(animatedProperty, animatedStartValue)
				.animate(animationEnd, {
				    queue: false,
				    duration: options.openDuration,
				    easing: 'linear',
				    complete: function() {
				        animationContainer.css('overflow', '');

				        if (end) end();
				    }
				});
        },

        rewind: function(options, end) {
            var animationContainer = this.animationContainer;

            this.element.stop();

            animationContainer.css({
                overflow: 'hidden'
            });

            var animatedProperty;

            switch (options.direction) {
                case 'bottom': animatedProperty = { marginTop: -this.element.outerHeight() };
                    break;
                case 'right': animatedProperty = { marginLeft: -this.element.outerWidth() }; break;
            }

            this.element
				.animate(animatedProperty, {
				    queue: false,
				    duration: options.closeDuration,
				    easing: 'linear',
				    complete: function() {
				        animationContainer
							.css({
							    display: 'none',
							    overflow: ''
							});

				        if (end) end();
				    }
				});
        }
    });

    $.telerik.fx.slide.defaults = function() {
        return { name: 'slide', openDuration: 'fast', closeDuration: 'fast' };
    };

    // property animation

    $.telerik.fx.property = function(element) {
        this.element = element;
    };

    $.extend($.telerik.fx.property.prototype, {
        _animate: function(properties, duration, reverse, end) {
            var startValues = { overflow: 'hidden' },
				endValues = {},
				$element = this.element;

            $.each(properties, function(i, prop) {
                var value;

                switch (prop) {
                    case 'height':
                    case 'width': value = $element[prop](); break;

                    case 'opacity': value = 1; break;

                    default: value = $element.css(prop); break;
                }

                startValues[prop] = reverse ? value : 0;
                endValues[prop] = reverse ? 0 : value;
            });

            $element
						 .css(startValues)
						 .show()
						 .animate(endValues, {
						     queue: false,
						     duration: duration,
						     easing: 'linear',
						     complete: function() {
						         if (reverse)
						             $element.hide();

						         $.each(endValues, function(property) {
						             endValues[property] = '';
						         });

						         $element.css($.extend({ overflow: '' }, endValues));

						         if (end) end();
						     }
						 });
        },

        play: function(options, complete) {
            this._animate(options.properties, options.openDuration, false, complete);
        },

        rewind: function(options, complete) {
            this._animate(options.properties, options.closeDuration, true, complete);
        }
    });

    $.telerik.fx.property.defaults = function() {
        return { name: 'property', properties: arguments, openDuration: 'fast', closeDuration: 'fast' };
    };
})(jQuery);
