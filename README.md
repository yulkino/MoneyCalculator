# MoneyCalculator
Для того чтобы воспользоваться программой надо добавить файл "d.txt" по пути в папку "\MoneyCalculator\bin\Debug\netcoreapp3.1\".
Файл должен иметь структуру, 
в первой строке которой перечисление участников через "; " (после последне не надо ставить разделитель),
а далее информация о покупках в виде:
Кто купил; Что купил; Цена(обязательно с ",", а не с "." и без знака валюты!); Участники(если несколько, то пишутся через "; ", после последнего "; " не ставится)


------------Пример------------
Участник1; Участник2; Участник3
Участник2; Пельмени; 100; Участник2; Участник3
Участник2; Молоко; 50,90; Участник3
Участник3; Хлеб; 99,99; Участник1; Участник2; Участник3
------------Пример------------


Обратите внимание, если в перечислении участников нет человека, который купил, это означает, что он не пользовался предметом и не будет за него платить!

Так как это демо-версия, то будьте внимательны: 
1) Не ставьте лишних пробелов
2) Не забывайте ставить между всем "; "
3) Пишите имена участников точно так, как указали в перечислении
4) Не добавляйте в перечисление предмета каких-либо новых лиц, которые не написаны в первой строке

Удачи! c:
