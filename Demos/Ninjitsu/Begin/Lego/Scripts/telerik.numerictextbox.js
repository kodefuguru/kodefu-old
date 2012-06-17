(function($) {

    var $t = $.telerik;
    var negativePattern = ['(n)', '-n', '- n', 'n-', 'n -'];

    $.extend($t, {
        numerictextbox: function(element, options) {

            this.element = element;
            var $element = $(element);

            $.extend(this, options);

            if ($t.cultureInfo.numberdecimaldigits) {
                this.digits = $t.cultureInfo.numberdecimaldigits;
                this.separator = $t.cultureInfo.numberdecimalseparator;
                this.groupSeparator = $t.cultureInfo.numbergroupseparator;
                this.groupSize = $t.cultureInfo.numbergroupsize;
                this.negative = $t.cultureInfo.numbernegative;
            }

            var pasteMethod = $.browser.msie ? 'paste' : 'input';

            var input = $('.t-input', element).hide();
            var inputValue = input.attr('value');
            $('<input>', {
                id: input.attr('id') + "-text",
                name: input.attr('name') + "-text",
                'class': input.attr('class'),
                value: (inputValue || this.text)
            })
            .blur($t.delegate(this, this.blur))
            .focus($t.delegate(this, this.focus))
            .keydown($t.delegate(this, this.keydown))
            .keypress($t.delegate(this, this.keypress))
	        .bind(pasteMethod, $t.delegate(this, this[pasteMethod]))
	        .insertAfter(input);

            $('.t-arrow-up', element).mouseup($t.delegate(this, this.up))
                                     .click($t.delegate(this, function(e) { e.preventDefault() }));

            $('.t-arrow-down', element).mouseup($t.delegate(this, this.down))
                                       .click($t.delegate(this, function(e) { e.preventDefault() }));

            var separator = this.separator;
            this.step = $t.parse(this.step, separator);
            this.val = $t.parse(this.val, separator);
            this.minValue = $t.parse(this.minValue, separator);
            this.maxValue = $t.parse(this.maxValue, separator);

            if (inputValue != '') { //format the input value if it exists.
                var parsedValue = $t.parse(input.attr('value'), this.separator);
                this.value(parsedValue);
            }

            if (this.onChange)
                $element.bind('changeNumericTextBox', this.onChange);

            if (this.onLoad)
                $element.bind('loadNumericTextBox', this.onLoad).trigger('loadNumericTextBox')
        }
    });

    $.extend($t.numerictextbox.prototype, {

        input: function(e, element) {

            var val = $(element).val();

            if (val == '-') return true;

            var parsedValue = $t.parse(val, this.separator);

            if (parsedValue || parsedValue == 0)
                this.trigger($t.round(parsedValue, this.digits));
        },

        paste: function(e, element) {
            var $input = $(element);
            var val = $input.val();
            var text = window.clipboardData.getData("Text");

            var parsedValue = $t.parse(val + text, this.separator);
            if (parsedValue || parsedValue == 0)
                this.trigger($t.round(parsedValue, this.digits));
        },

        focus: function(e, element) {
            this.focused = true;

            if (document.selection) { //if IE
                var oSel = element.document.selection.createRange();
                oSel.moveStart('character', -element.value.length);
                oSel.collapse();
                oSel.select();
            }

            var value = this.formatEdit(this.val);
            $(element).val(value || (value == 0 ? 0 : ''));
        },

        blur: function(e) {
            var $input = $(e.target);

            this.focused = false;
            var inputValue = $input.val();
            if (!inputValue && inputValue != '0' || !this.val && this.val != 0) {
                this.value(null);
                $input.removeClass('t-state-error')
                      .val(this.text || '');
                return true;
            } else {
                if ($t.range(this.val, this.minValue, this.maxValue)) {
                    $input.val(this.format($t.round(this.val, this.digits)));
                    $input.removeClass('t-state-error');
                }
                else {
                    $input.addClass('t-state-error');
                }
            }
        },

        keydown: function(e, element) {
            var key = e.keyCode;
            var $input = $(element);
            var separator = this.separator;

            // Allow decimal
            var decimalSeparator = $t.decimals[key];
            if (decimalSeparator) {
                if (decimalSeparator == separator && this.digits > 0
                    && $t.caretPos($input[0]) != 0 && $input.val().indexOf(separator) == -1) {
                    return true;
                } else {
                    e.preventDefault();
                }
            }

            if (key == 8 || key == 46) { //backspace and delete
                setTimeout($t.delegate(this, function() {
                    this.parseTrigger($input.val());
                }));
                return true;
            }

            if (key == 38 || key == 40) {
                this.modifyInput($input, this.step * (key == 38 ? 1 : -1));
                return true;
            }

            if (key == 222) e.preventDefault();
        },

        keypress: function(e) {
            var $input = $(e.target);
            var key = e.keyCode || e.which;

            if ($.inArray(key, $t.keycodes) != -1 || e.ctrlKey || (e.shiftKey && key == 45)) return true;

            if ((this.minValue < 0 && String.fromCharCode(key) == "-"
                && $t.caretPos($input[0]) == 0 && $input.val().indexOf("-") == -1)
                || $t.range(key, 48, 57)) {
                setTimeout($t.delegate(this, function() {
                    this.parseTrigger($input.val());
                }));
                return true;
            }

            e.preventDefault();
        },

        up: function(e) {
            this.modifyInput($('.t-input:last', this.element), this.step);
        },
        down: function(e) {
            this.modifyInput($('.t-input:last', this.element), -this.step);
        },

        value: function(value) {
            if (arguments.length == 0) return this.val;

            var parsedValue = $t.parse(value, this.separator);
            var isNull = parsedValue === null;
            
            this.val = parsedValue;
            $('.t-input:first', this.element).val(isNull ? '' : this.formatEdit(parsedValue));
            $('.t-input:last', this.element)
                    .toggleClass('t-state-error', !$t.range(this.val, this.minValue, this.maxValue))
                    .val(isNull ? this.text : this.format(parsedValue));
            return this;
        },

        modifyInput: function(input, step) {

            var value = $t.change(this.val, step, this.minValue, this.maxValue);
            if (value || value == 0) {
                var fixedValue = $t.round(value, this.digits);

                this.trigger(fixedValue);

                var formatedValue = this.focused ? this.formatEdit(fixedValue) : this.format(fixedValue);

                input.removeClass('t-state-error')
                     .val(formatedValue);
            }
        },

        formatEdit: function(value) {
            var separator = this.separator;
            if (value && separator != '.')
                value = value.toString().replace('.', separator);
            return value;
        },

        format: function(value) {
            var tokens = value.toString().split('.');
            var number = tokens[0].replace('-', '');
            var builder = new $t.stringBuilder();

            for (var i = 0, j = number.length; i < j; i++) {
                if (i != 0 && (j - i) % this.groupSize == 0) builder.cat(this.groupSeparator);
                builder.cat(number.charAt(i));
            }

            if (tokens.length > 1) builder.cat(this.separator).cat(tokens[1]);

            return this.val < 0 ? negativePattern[this.negative].replace('n', builder.string()) : builder.string();
        },

        trigger: function(newValue) {
            if (this.val != newValue) {
                $t.trigger(this.element, 'changeNumericTextBox', { oldValue: this.val, newValue: newValue });
                $('.t-input:first', this.element).val(this.formatEdit(newValue));
                this.val = newValue;
            }
        },

        parseTrigger: function(value) {
            var parsedValue = $t.parse(value, this.separator);
            if (parsedValue || parsedValue == 0)
                this.trigger($t.round(parsedValue, this.digits));
        }
    });

    $.fn.tNumericTextBox = function(options) {
        options = $.extend({}, $.fn.tNumericTextBox.defaults, options);

        return this.each(function() {
            options = $.meta ? $.extend({}, options, $(this).data()) : options;

            if (!$(this).data('tNumericTextBox'))
                $(this).data('tNumericTextBox', new $t.numerictextbox(this, options));
        });
    };

    $.fn.tNumericTextBox.defaults = {
        val: null,
        minValue: -100,
        maxValue: 100,
        step: 1,
        digits: 2,
        separator: '.',
        groupSeparator: ',',
        groupSize: 3,
        negative: 1
    };
})(jQuery);