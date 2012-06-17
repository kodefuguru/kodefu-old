(function($) {
    var $t = $.telerik;
    var escapeQuoteRegExp = /'/ig;
    var filterFunctions = ['startswith', 'substringof', 'endswith'];
    var formatRegExp = /\{0(:([^\}]+))?\}/;

    var filterCommandsByType = {
        'String': {
            'Is equal to': 'eq',
            'Is not equal to': 'ne',
            'Starts with': 'startswith',
            'Contains': 'substringof',
            'Ends with': 'endswith'
        },
        'Number': {
            'Is equal to': 'eq',
            'Is not equal to': 'ne',
            'Is less than': 'lt',
            'Is less than or equal to': 'le',
            'Is greater than': 'gt',
            'Is greater than or equal to': 'ge'
        },
        'Date': {
            'Is equal to': 'eq',
            'Is not equal to': 'ne',
            'Is before': 'lt',
            'Is before or equal to': 'le',
            'Is after': 'gt',
            'Is after or equal to': 'ge'
        }
    };

    var fx = [$t.fx.slide.defaults()];

    $t.filtering = {};

    $t.filtering.initialize = function(grid) {
        $.extend(grid, $t.filtering.implementation);

        $('.t-grid-content', grid.element).bind('scroll', function() {
            grid.hideFilter();
        });

        $(document).click($t.delegate(grid, grid.filterDocumentClick));

        $('.t-grid-filter', grid.element)
			.click($t.delegate(grid, grid.showFilter))
			.live('mouseenter', $t.hover)
			.live('mouseleave', $t.leave);

        $('.t-filter-options .t-button', grid.element)
			.live('mouseenter', $t.buttonHover)
			.live('mouseleave', $t.buttonLeave);
    }

    /* Here `this` is the Grid instance*/

    $t.filtering.implementation = {
        createFilterCommands: function(stringBuilder, column) {
            var filters = filterCommandsByType[column.type];

            stringBuilder.cat('<select>');

            for (var filter in filters)
                stringBuilder
					.cat('<option value="')
					.cat(filters[filter])
					.cat('">')
					.cat(filter)
					.cat('</option>');

            stringBuilder
				.cat('</select>');
        },

        createTypeSpecificInput: function(stringBuilder, column, fieldId, value) {
            if (column.type == 'Date') {
                stringBuilder
	                .cat('<div class="t-widget t-datepicker">')
	                .cat('<input class="t-input" id="')
	                .cat(fieldId)
	                .cat('" type="text" value="" />')
	                .cat('<label class="t-icon t-icon-calendar" for="')
	                .cat(fieldId)
	                .cat('" title="Open the calendar popup." /></div>');
            } else if (column.type == 'Boolean') {
                stringBuilder
                    .cat('<div><input type="radio" style="width:auto;display:inline" id="').cat(fieldId + value)
				    .cat('" name="').cat(fieldId)
				    .cat('" value="').cat(value).cat('" />')
				    .cat('<label style="display:inline" for="').cat(fieldId + value)
				    .cat('">is ').cat(value)
				    .cat('</label></div>');
            } else {
                stringBuilder.cat('<input type="text" />');
            }
        },

        createFilterMenu: function(column) {
            var filterMenuHtml = new $t.stringBuilder();

            filterMenuHtml.cat('<div class="t-animation-container"><div class="t-filter-options t-group" style="display:none">')
					.cat('<button class="t-button t-state-default t-clear-button"><span class="t-icon t-clear-filter"></span>Clear Filter</button>')
					.cat('<div class="t-filter-help-text">Show rows with value that</div>');

            var fieldIdPrefix = $(this.element).attr('id') + column.member;

            if (column.type == 'Boolean') {
                this.createTypeSpecificInput(filterMenuHtml, column, fieldIdPrefix, true);
                this.createTypeSpecificInput(filterMenuHtml, column, fieldIdPrefix, false);
            } else {
                this.createFilterCommands(filterMenuHtml, column);
                this.createTypeSpecificInput(filterMenuHtml, column, fieldIdPrefix + 'first');
                filterMenuHtml.cat('<div class="t-filter-help-text">And</div>');
                this.createFilterCommands(filterMenuHtml, column);
                this.createTypeSpecificInput(filterMenuHtml, column, fieldIdPrefix + 'second');
            }

            filterMenuHtml.cat('<button class="t-button t-state-default t-filter-button"><span class="t-icon t-filter"></span>Filter</button>')
				          .cat('</div></div>');

            return $(filterMenuHtml.string())
                        .appendTo(this.element)
                        .find('.t-datepicker').tDatePicker().end();
        },

        showFilter: function(e, element) {
            e.stopPropagation();
            this.hideFilter(function() {
                return this.parentNode != element;
            });

            var $element = $(element);
            var $filterMenu = $element.data('filter');

            if (!$filterMenu) {
                // filtering menu should be created
                var column = this.columns[this.$columns().index($element.parent())];

                $filterMenu = this.createFilterMenu(column)
                        .data('column', column)
                        .click(function(e) {
                            e.stopPropagation();

                            if ($(e.target).parents('.t-datepicker').length == 0) {
                                $('.t-datepicker', this)
                                    .each(function() {
                                        $(this).data('tDatePicker').hidePopup();
                                    });
                            }
                        })
                        .find('.t-filter-button').click($t.delegate(this, this.filterClick)).end()
                        .find('.t-clear-button').click($t.delegate(this, this.clearClick)).end()
                        .find('input[type=text]').keyup($t.delegate(this, this.filterKeyUp)).end();

                $element.data('filter', $filterMenu);
            }

            // position filtering menu
            var top = 0;
            $('thead, .t-grid-header, .t-grouping-header, .t-grid-toolbar', this.element).each(function() {
                top += this.offsetHeight;
            });
            var position = { top: top };
            var parent = $element.parent()[0];
            var headerRow = $element.parent().parent();
            var width = -this.$headerWrap.scrollLeft() - 1;

            headerRow.find('.t-header').each(function() {
                width += this.offsetWidth;
                if (this == parent)
                    return false;
            });

            var left = width - element.offsetWidth;

            // constrain filtering menu within grid
            var outerWidth = $filterMenu.outerWidth() || $filterMenu.find('.t-group').outerWidth();

            if (left + outerWidth > headerRow.outerWidth())
                left = width - outerWidth + 1;

            if ($(this.element).hasClass('t-grid-rtl'))
                position['right'] = left + ($.browser.mozilla || $.browser.safari ? 18 : 0);
            else
                position['left'] = left;

            $filterMenu.css(position);

            $t.fx[$filterMenu.find('.t-filter-options').is(':visible') ? 'rewind' : 'play'](fx, $filterMenu.find('.t-filter-options'), { direction: 'bottom' });
        },

        hideFilter: function(filterCallback) {
            filterCallback = filterCallback || function() { return true; };

            $('.t-filter-options .t-datepicker', this.element)
                .each(function() { $(this).data('tDatePicker').hidePopup(); });

            $('.t-filter-options', this.element)
                .filter(filterCallback)
                .each(function() {
                    $t.fx.rewind(fx, $(this), { direction: 'bottom' });
                });
        },

        getColumn: function($element) {
            return $element.closest('.t-animation-container').data('column');
        },

        clearClick: function(e, element) {
            e.preventDefault();
            var $element = $(element);
            var column = this.getColumn($element);
            column.filters = null;

            $element.parent()
                    .find('input, select')
                    .val('')
                    .removeAttr('checked')
                    .removeClass('t-state-error');

            this.filter(this.filterExpr());
        },

        filterClick: function(e, element) {
            e.preventDefault();
            var $element = $(element);
            var column = this.getColumn($(element));
            column.filters = [];
            var hasErrors = false;

            $element.parent().children('input[type=text]').each($.proxy(function(index, input) {
                var $input = $(input);
                var value = $.trim($input.val());

                if (!value) {
                    $input.removeClass('t-state-error');
                    return true;
                }

                var valid = this.isValidFilterValue(column, value);

                $input.toggleClass('t-state-error', !valid);

                if (!valid) {
                    hasErrors = true;
                    return true;
                }

                var operator = $input.prev('select').val() || $input.parent().prev('select').val();
                column.filters.push({ operator: operator, value: value });
            }, this));

            $element.parent().find('input:checked').each($.proxy(function(index, input) {
                var $input = $(input);
                var value = $(input).attr('value');
                column.filters.push({ operator: 'eq', value: value });
            }, this));

            if (!hasErrors) {
                if (column.filters.length > 0)
                    this.filter(this.filterExpr());

                this.hideFilter();
            }
        },

        filterKeyUp: function(e, element) {
            if (e.keyCode != 13)
                return;
            this.filterClick(e, element);
        },

        filterDocumentClick: function(e, element) {
            if (e.which == 3)
                return;

            this.hideFilter();
        },

        isValidFilterValue: function(column, value) {
            if (column.type == 'Number') {
                return !isNaN(value);
            }

            return true;
        },

        parseDate: function(column, value) {
            return new Date(Date.parse(value));
        },

        getFormat: function(column) {
            var match = formatRegExp.exec(column.format);
            return match ? match[2] : $t.cultureInfo.shortDate;
        },

        encodeFilterValue: function(columnIndex, value) {
            var column = this.columns[columnIndex];
            switch (column.type) {
                case 'String':
                    return "'" + value.replace(escapeQuoteRegExp, "''") + "'";
                case 'Date':
                    var date = this.parseDate(column, value);
                    return "datetime'" + $t.formatString('{0:yyyy-MM-ddThh-mm-ss}', date) + "'";
            }

            return value;
        },

        filterExpr: function() {
            var result = [];
            for (var columnIndex = 0, length = this.columns.length; columnIndex < length; columnIndex++) {
                var column = this.columns[columnIndex];

                if (!column.filters)
                    continue;

                for (var filterIndex = 0; filterIndex < column.filters.length; filterIndex++) {
                    var filter = column.filters[filterIndex];
                    var expr = new $t.stringBuilder();
                    if ($.inArray(filter.operator, filterFunctions) > -1) {
                        expr.cat(filter.operator)
                        .cat('(')
                        .cat(column.member)
                        .cat(',')
                        .cat(this.encodeFilterValue(columnIndex, filter.value))
                        .cat(')');
                    } else {
                        expr.cat(column.member)
                        .cat('~')
                        .cat(filter.operator)
                        .cat('~')
                        .cat(this.encodeFilterValue(columnIndex, filter.value));
                    }
                    result.push(expr.string());
                }
            }

            return result.join('~and~');
        },

        filter: function(filterBy) {
            this.currentPage = 1;
            this.filterBy = filterBy;

            if (!this.isAjax())
                location.href = $t.formatString(unescape(this.urlFormat),
                    this.currentPage, this.orderBy || '~', escape(this.filterBy) || '');
            else {
                this.$columns().each($.proxy(function(index, element) {
                    $('.t-grid-filter', element)
                        .toggleClass('t-active-filter', !!this.columns[index].filters);
                }, this));
                this.ajaxRequest();
            }
        }
    };
})(jQuery);
