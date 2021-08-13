# PizzaRobot
Проект представвляет собой консольное приложение, составляющее путь для робота-доставщика пиццы
___
## Робот
[Класс робота](PizzaRobot/Robot.cs) содержит в себе методы для [парсинга ввода](https://github.com/KostyaTolok/TechTask/blob/d222147c625f58d5668e369a4a51a372aca4b327/PizzaRobot/Robot.cs#L34) и [нахождения пути](https://github.com/KostyaTolok/TechTask/blob/d222147c625f58d5668e369a4a51a372aca4b327/PizzaRobot/Robot.cs#L75).
Для хранения точек на пути робота используется список из [классов](PizzaRobot/Point.cs) наследующих от [AbstractPoint](PizzaRobot/AbstractPoint.cs), для создания точек используется [фабрика](PizzaRobot/PointFactory.cs), реализующая [IPointFactory](PizzaRobot/IPointFactory.cs).
## Граф
Для поиска пути робот использует класс [Graph](PizzaRobot/Graph.cs). Изначально граф [заполняется](https://github.com/KostyaTolok/TechTask/blob/d222147c625f58d5668e369a4a51a372aca4b327/PizzaRobot/Graph.cs#L107) вершинами. [Вершины](PizzaRobot/Vertex.cs) заполняются соседними вершинами.
[Метод поиска пути](https://github.com/KostyaTolok/TechTask/blob/d222147c625f58d5668e369a4a51a372aca4b327/PizzaRobot/Graph.cs#L60) использует поиск в ширину и
возвращает список вершин до искомой вершины, а класс робота преобразует путь в строку.
Вершины также хранят классы наследующие от [AbstractPoint](PizzaRobot/AbstractPoint.cs).
## Запуск
Для запуска скачайте .exe, .json и .dll файлы и запустите exe файл.
