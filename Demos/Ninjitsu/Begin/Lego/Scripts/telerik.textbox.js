(function($) {

    var $t = $.telerik;
    
    $.extend($t, {
        decimals: { '190': '.', '110': '.', '188': ',' },
        keycodes: [8, 9, 37, 38, 39, 40, 46, 35, 36, 44], //44 is ","
    
        caretPos: function(element) {
            var pos = -1;

            if (document.selection) {
                var oSel = element.document.selection.createRange();
                oSel.moveStart('character', -element.value.length);
                pos = oSel.text.length;
            }
            else if (element.selectionStart || element.selectionStart == "0") {
                pos = element.selectionStart;
            }

            return pos;
        },

        range: function(key, min, max) { return key >= min && key <= max; },

        change: function(value, step, min, max) {
            value = value ? value + step : step;
            if (value >= min && value <= max)
                return value;
            else
                return null;
        },

        parse: function(value, separator) {
            var result = null;
            if (value) {
                if (separator && separator != '.')
                    value = value.replace(separator, '.');
                    
                result = parseFloat(value);
            }
            return isNaN(result) ? null : result;
        },
        
        round: function(value, digits) {
            if (value || value == 0)
                return parseFloat(value.toFixed(digits || 2));
            return null;
        }
    });

})(jQuery);