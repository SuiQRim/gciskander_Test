# gciskander_Test

## Описание
При получении списка слов (базы данных слов), он помещается к классу Continuer, который хранит в себе слова в отсортированном виде. Далее, когда мы хотим получить продолжения для слова, используется алгоритм бинарного поиска диапазона подходящий слов. Т.е. бинарным поиском в списке ищется самое первое слово, которое начинается с нужного префикса, и самое последнее. Этот диапазон далее сортируется по частоте и потом по алфавиту, после чего берутся первые 10 значений. Расчет поиска продолжений слов происходит параллельно.

## Запуск
В Program.cs нужно указать путь к файлу, с которого нужно считать данные. Также нужно указать, где создать файл с результатом

## Пример
Расчет данных файла из ТЗ (100_000+ записей) с учетом чтения и записи файла (Ryzen 7 3700)

![image](https://github.com/SuiQRim/gciskander_Test/assets/84430915/d4f71f4b-e660-47fc-8af5-c363e0e63720)
