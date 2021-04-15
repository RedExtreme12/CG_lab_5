# Лабораторная №2 (Компьютерная графика)

## Рогозенко Дмитрий

Приложение было реализовано на C# с использованием Windows Forms.

## Описание

### Пример работы с приложением

![Work example](https://github.com/RedExtreme12/CG_lab_5/blob/master/screens/work_example.gif)

### Краткое руководство

В правой части окна приложения находится поле для ввода данных. Под этим полем находятся кнопки ```Interpret as line clip``` и ```Interpret as polygon clip```, отвечающие за интерпретацию введёных данных как скрипта визуализации отсечения отрезков или скрипта визуализации отсечения выпуклого многоугольника соответственно.

Скрипт отсечения отрезков должен иметь следующий формат:

"line1X0 line1Y0 line1X1 line1Y1
...
lineNX0 lineNY0 lineNX1 lineNY1
clippingRectX0 clippingRectY0 clippingRectX1 clippingRectY1"
