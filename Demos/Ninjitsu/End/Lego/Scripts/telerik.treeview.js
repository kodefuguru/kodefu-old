(function($) {

    var $t = $.telerik;

    $t.treeView = function(element, options) {
        this.element = element;
        var $me = this.element;

        // attach options to object
        $.extend(this, options);

        $('.t-in:not(.t-state-selected,.t-state-disabled)', this.element)
               .live('mouseenter', $.telerik.hover)
               .live('mouseleave', $.telerik.leave)
               .live('click', $t.delegate(this, this.nodeSelect));

        $('.t-in:not(.t-state-disabled)', this.element)
               .live('dblclick', $t.delegate(this, this.nodeToggle))

        $('.t-plus:not(.t-plus-disabled), .t-minus:not(.t-minus-disabled)', this.element)
               .live('click', $t.delegate(this, this.nodeToggle));

        $(':checkbox', this.element)
               .live('click', $t.delegate(this, this.updateCheckState));

        var $element = $(this.element);

        if (this.onExpand)
            $element.bind('expandTreeView', this.onExpand);

        if (this.onCollapse)
            $element.bind('collapseTreeView', this.onCollapse);

        if (this.onSelect)
            $element.bind('selectTreeView', this.onSelect);

        if (this.onError)
            $element.bind('errorTreeView', this.onError);

        if (this.onLoad) {
            $element.bind('loadTreeView', this, this.onLoad);
            $t.trigger($element, 'loadTreeView');
        }
    }

    $t.treeView.prototype = {

        nodeSelect: function(e, element) {

            if (!$t.trigger(this.element, 'selectTreeView', { item: $(element).closest('.t-item')[0] })) {
                $('.t-in', this.element).removeClass('t-state-hover t-state-selected');

                $(element).addClass('t-state-selected');
            }
        },

        nodeToggle: function(e, element) {

            e.preventDefault();

            var $element = $(element);
            var $item = $element.closest('.t-item');

            if ($element.hasClass('t-plus-disabled') || $element.hasClass('t-minus-disabled'))
                return;
                
            if ($item.find('> div > .t-in').hasClass('t-state-disabled'))
                return;

            var contents = $item.find('> .t-group');
            var isExpanding = !contents.is(':visible');

            if (isExpanding && this.isAjax() && contents.length == 0) {
                this.ajaxRequest($item);
            }
            else if (contents.children().length > 0) {
                var isEventPrevented = false;

                if (isExpanding) {
                    isEventPrevented = $t.trigger(this.element, 'expandTreeView', { item: $item[0] });
                } else {
                    isEventPrevented = $t.trigger(this.element, 'collapseTreeView', { item: $item[0] });
                }

                if (!isEventPrevented) {
                    $item.find('> div > .t-icon')
                        .toggleClass('t-minus', isExpanding)
                        .toggleClass('t-plus', !isExpanding);

                    contents.toggle();
                }
            }
        },

        isAjax: function() {
            return this.ajax || this.ws;
        },

        url: function(which) {
            return (this.ajax || this.ws)[which];
        },

        ajaxOptions: function($item, options) {
            var result = {
                type: 'POST',
                dataType: 'text',
                error: $.proxy(function(xhr, status) {
                    if ($t.ajaxError(this.element, 'error', xhr, status))
                        return;

                    if (status == 'parsererror')
                        alert('Error! The requested URL did not return JSON.');
                }, this),

                success: $.proxy(function(data) {
                    data = eval("(" + data + ")");
                    data = data.d || data; //Support the `d` returned by MS Web Services
                    this.dataBind($item, data);
                }, this)
            };
            $.extend(result, options);

            var node = this.ws ? result.data.node = {} : result.data;

            node[this.queryString.value] = this.getItemValue($item);
            node[this.queryString.text] = this.getItemText($item);

            if (this.ws) {
                result.data = $t.toJson(result.data);
                result.contentType = 'application/json; charset=utf-8';
            }

            return result;
        },

        ajaxRequest: function($item) {

            if (!this.isAjax())
                return;

            $item.data('loadingIconTimeout', setTimeout(function() {
                $item.find('> div > .t-icon').addClass('t-loading');
            }, 100));

            $.ajax(this.ajaxOptions($item, {
                data: {},
                url: this.url('selectUrl')
            }));
        },

        dataBind: function($item, data) {

            if (data.length == 0) {
                $('.t-icon', $item).remove();
                return;
            }

            var validateData = function(model) {
                var isValid = false;
                $.each(['Text', 'Value', 'LoadOnDemand'], function(index, property) {
                    isValid = false;
                    for (var key in model) {
                        if (key == property) {
                            isValid = true;
                            break;
                        }
                    }

                    if (!isValid) {
                        return false;
                    }
                });

                return isValid;
            }

            if (!validateData(data[0])) {
                alert("Invalid Object");
                return;
            }

            if (data.length == 0) {
                $('.t-icon', $item).remove();
            }

            var html = new $t.stringBuilder();
            html.cat('<ul class="t-group">');

            for (var key in data) {
                var itemCssClass = "t-item";
                var itemDivCssClass;

                if (key == 0) {
                    itemCssClass += " t-first";
                    itemDivCssClass = "t-top";
                }
                else if (key == data.length - 1) {
                    itemCssClass += " t-last";
                    itemDivCssClass = "t-bot";
                }
                else {
                    itemDivCssClass = "t-mid";
                }

                if (!data[key].Enabled) {
                    itemCssClass += " t-state-disabled";
                }

                html.cat($t.formatString('<li class="{0}">', itemCssClass))
                    .cat($t.formatString('<div class="{0}">', itemDivCssClass))
                    .catIf('<span class="t-icon t-plus"></span>', data[key].LoadOnDemand)
                    .catIf($t.formatString('<span"><input type="checkbox" value="{0}" class="t-input" {1} /></span>', data[key].Value, data[key].Checked ? "checked" : ''), this.ShowCheckBox)
                    .cat(data[key].NavigateUrl ? '<a class="t-link t-in">' : '<span class="t-in">')
                    .catIf('<img class="t-image" alt="" src="{0}" />', data[key].ImageUrl != null)
                    .cat(data[key].Text)
                    .cat(data[key].NavigateUrl ? '</a>' : '</span>')
                    .cat('</div>')
                    .catIf($t.formatString('<input type="hidden" value="{0}" class="t-input" />', data[key].Value), data[key].LoadOnDemand)
                    .cat('</li>');
            }

            html.cat('</ul>');

            clearTimeout($item.data('loadingIconTimeout'));

            $(html.string()).appendTo($item);

            $('.t-icon:first', $item)
                .removeClass('t-loading')
                .removeClass('t-plus')
                .addClass('t-minus');
        },

        updateCheckState: function(e, element) {

            var $element = $(element);
            var $item = $element.closest('.t-item');
            var isChecked = $element.is(':checked');

            var data = $t.formatString('{0}:{1}', $element.attr('value'), this.getItemText($item));
            var index = $.inArray(data, this.checkedNodes);

            if (!isChecked)
                this.checkedNodes.splice(index, 1);
            else
                this.checkedNodes.push(data);

            var checkedString = '';
            for (var i = 0; i < this.checkedNodes.length; i++) {
                checkedString += '\"' + this.checkedNodes[i] + '\"';
                if (i < this.checkedNodes.length - 1) {
                    checkedString += ",";
                }
            }
            $(".t-state", this.element).attr('value', '{\"CheckedNodes\":[' + checkedString + ']}')
        },

        getItemText: function($item) {
            return $('.t-in:first', $item).text();
        },

        getItemValue: function($item) {
            return $(':hidden:last', $item).val();
        }
    }

    $.fn.tTreeView = function(options) {
        options = $.extend({}, $.fn.tTreeView.defaults, options);

        return this.each(function() {
            options = $.meta ? $.extend({}, options, $(this).data()) : options;

            if (!$(this).data('tTreeView')) {
                var treeview = new $t.treeView(this, options);

                $(this).data('tTreeView', treeview);
            }
        });
    }

    // default options
    $.fn.tTreeView.defaults = {
        queryString: {
            text: 'Text',
            value: 'Value'
        }
    };
})(jQuery);