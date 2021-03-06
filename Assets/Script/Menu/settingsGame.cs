﻿using UnityEngine;
using System.Collections.Generic;

public class settingsGame: MonoBehaviour {



		public  List<string> languages;

		void Awake()

		{
				if(PlayerPrefs.GetString ("languages") == "")
				{
						PlayerPrefs.SetString ("languages", "English");
				}

				languagesGame ();
		}







		public  void languagesGame()
		{
				languages.Clear();


				if (PlayerPrefs.GetString ("languages") == "Russian")
				{
						languages.Add("Продол-\nжить\nигру");//0
						languages.Add("Новая\nигра");
						languages.Add("Трени-\nровка");
						languages.Add("Обучение");
						languages.Add("Рейтинг\nигроков");
						languages.Add("Настройки");
						languages.Add("Выход");
						languages.Add("Оценить\nигру");
						languages.Add("Звук:");
						languages.Add("Включить");
						languages.Add("Выклю-\nчить");//10
						languages.Add("Назад");
						languages.Add("ЗОЛОТО");
						languages.Add("ХОДОВ");
						languages.Add("ДОБАВИТЬ");
						languages.Add("УРОВЕНЬ");
						languages.Add("ВРЕМЯ");
						languages.Add("Легкий\nрестарт");
						languages.Add("Меню");
						languages.Add("Вернуться в\nигру");
						languages.Add("Купить\nзолото");//20
						languages.Add("Выход в\nменю");
						languages.Add("На данный момент у Вас:");
						languages.Add("золота");
						languages.Add("Добавить еще:");
						languages.Add("золота за");
						languages.Add("Перейти к оплате");
						languages.Add("Некоторые функции игры требуют аккаунта на нашем сервисе\nи постоянного доступа в интернет");
						languages.Add("Введите свой логин:");
						languages.Add("Введите свой пароль:");
						languages.Add("Войти");//30
						languages.Add("Быстрая регистрация");
						languages.Add("Войти без регистрации");
						languages.Add("Повторите пароль");
						languages.Add("Зарегистрироваться");
						languages.Add("Назад");
						languages.Add("Поздравляем!");
						languages.Add("Вы прошли уровень");
						languages.Add("ВАШЕ ВРЕМЯ");
						languages.Add("ВАШИ ХОДЫ");
						languages.Add("На следующий уровень");//40
						languages.Add("Повторить уровень");
						languages.Add("НЕ ОСТАЛОСЬ ХОДОВ");
						languages.Add("Извините, но Вы потратили свои ходы.");
						languages.Add("Выберите один из вариантов");
						languages.Add("Добавить ходов");
						languages.Add("Легкий рестарт");
						languages.Add("Главное\nменю");
						languages.Add("ходов за");
						languages.Add("КУПИТЬ");
						languages.Add("У каждого игрока есть возможность использовать кнопку легкий рестарт. При нажатии данной кнопки, уровень начнется заново, но с самого начала у игрока будут собраны все линии, кроме 2-х последних.");//50
						languages.Add("Стоимость:");
						languages.Add("ДОБАВИТЬ ХОДЫ");
						languages.Add("Легкий рестарт");
						languages.Add("Купить золото");
						languages.Add("ИМЯ ИГРОКА");
						languages.Add("ХОДЫ");
						languages.Add("Смена\nаккаунта");
						languages.Add("Проверьте ввод данных.\nВ одном из полей ошибка.");
						languages.Add("Данный логин уже занят.");
						languages.Add("Проверьте ввод данных.\nНе совпадают пароли или пустые поля ввода");//60
						languages.Add("Проверьте ввод данных.\nВы не ввели свой логин");
						languages.Add("Закрыть");
						languages.Add("Сменить аккаунт");
						languages.Add("ПОДТВЕРДИВ СМЕНУ АККАУНТА:\nВЫ ПОКИНЕТЕ УРОВЕНЬ\nИ ПЕРЕЙДЕТЕ НА СТРАНИЦУ\nВХОДА И РЕГИСТРАЦИИ");
						languages.Add("ПОДТВЕРДИТЬ");
						languages.Add("ОТМЕНА");
						languages.Add("Выбор\nуровня");
						languages.Add("Дальше");
						languages.Add("Начать\nобучение");//69
						languages.Add("Добро пожаловать в нашу игру!");//70
						languages.Add("Для того, чтобы разобраться с правилами игры, мы подготовили для Вас короткое обучение.");
						languages.Add("Главная цель игры");
						languages.Add("собрать каждый цвет в вертикальную линию");
						languages.Add("Игрок имеет возможность передвигать цветные кубики по двум осям: по вертикали и горизонтали");
						languages.Add("У игрока есть возможность перемещать по вертикали каждый кубик по отдельности");
						languages.Add("Но по горизонтали двигается вся строка целиком");
						languages.Add("Вверху игрового поля есть перемещаемая резервная ячейка, в которую можно временно переместить любой из цветных кубиков, находящихся на верхней горизонтали.");
						languages.Add("Ходом считается перемещение цветного кубика из верхней резервной ячейки вниз на игровое поле.");
						languages.Add("На прохождение уровня выделяется 10 ходов и неограниченное количество времени. Но чем меньше времени и ходов Вы потратите - тем выше будет Ваша позиция в рейтинге.");
						languages.Add("Ваше обучение окончено. Вы в любой момент можете повторить его из главного меню игры.");//80
						languages.Add("Закончить");
						languages.Add("ДА");
						languages.Add("НЕТ");
						languages.Add("Для участия в общем рейтинге зарегистрируйтесь");
						languages.Add("Вы прошли все уровни");
						languages.Add("Для участия в общем рейтинге подключитесь к интернету");
						languages.Add("Новая игра");
						languages.Add("Для регистрации и входа в аккаунт, \nнеобходимо подключение к сети интернет");
						languages.Add("Вы уверены, что хотите выйти? \n Весь Ваш текущий прогресс на уровне не будет сохранен");
				}

				if (PlayerPrefs.GetString ("languages") == "English")
				{
						languages.Add("Continue\ngame");
						languages.Add("New\ngame");
						languages.Add("Training\nroom");
						languages.Add("Learning");
						languages.Add("Leader\nboard");
						languages.Add("Settings");
						languages.Add("Exit");
						languages.Add("Rate\nthis game");
						languages.Add("Sound:");
						languages.Add("ON");
						languages.Add("OFF");//10
						languages.Add("Back");
						languages.Add("GOLD");//12
						languages.Add("MOVES");//13
						languages.Add("ADD");//14
						languages.Add("LEVEL");//15
						languages.Add("TIME");//16
						languages.Add("Easy\nrestart");
						languages.Add("Menu");
						languages.Add("Back\nto game");
						languages.Add("BUY\nGOLD");//20
						languages.Add("Exit\nto menu");
						languages.Add("Currently you have:");
						languages.Add("gold");
						languages.Add("ADD:");
						languages.Add("gold");
						languages.Add("PROCEED TO CHECKOUT");
						languages.Add("Some features of games require an account in our service,\nand sustainable access to the Internet");
						languages.Add("Enter your username:");
						languages.Add("Enter your password:");
						languages.Add("Sign in");//30
						languages.Add("Fast registration");
						languages.Add("Login without registration");
						languages.Add("Repeat password");
						languages.Add("Sign up");
						languages.Add("Back");
						languages.Add("Congratulations!");
						languages.Add("You have passed the level");
						languages.Add("YOUR TIME");
						languages.Add("YOUR MOVES");
						languages.Add("Next level");//40
						languages.Add("Retry level");
						languages.Add("MOVES ARE ENDED");
						languages.Add("Sorry, but You spent your moves.");
						languages.Add("Select an option");
						languages.Add("Add moves");
						languages.Add("Easy restart");
						languages.Add("Main\nmenu");
						languages.Add("moves for");
						languages.Add("BUY");
						languages.Add("Each player has the opportunity to use the button   'EASY RESTART'. When this button is pressed, the level will restart. But the player has collected all lines from the beginning except the last 2.");//50
						languages.Add("Cost:");
						languages.Add("Add moves");
						languages.Add("Easy restart");
						languages.Add("Buy gold");
						languages.Add("PLAYER NAME");
						languages.Add("MOVES");
						languages.Add("Change\naccount");
						languages.Add("Check the input data.\nOne of the fields has error.");
						languages.Add("This login is already in use.");
						languages.Add("Check the input data.\nPassword does not match or an empty input field");//60
						languages.Add("Check the input data.\nYou did not enter your username");
						languages.Add("Close");
						languages.Add("Change account");
						languages.Add("IF YOY CONFIRM\nYOU LEAVE THE LEVEL\nAND GO TO THE LOGIN PAGE");
						languages.Add("CONFIRM");
						languages.Add("CANCEL");
						languages.Add("Select\nlevel");
						languages.Add("Continue");
						languages.Add("Start\nlearning");//69
						languages.Add("Welcome to our game!");//70
						languages.Add("In order to understand the rules of the game, we have prepared for You a short training."); //71
						languages.Add("The main goal of the game");//72
						languages.Add("is collect every color in a vertical line");
						languages.Add("The player has the ability to move the colored cubes along two axes: vertically and horizontally");
						languages.Add("The player has the ability to move vertically each cube individually");
						languages.Add("But the horizontal string is moving entirely");
						languages.Add("At the top of the game board you can see movable reserve cell. You can temporarily move  to this cell any of the colored blocks, which located in the upper horizontally.");
						languages.Add("The movement of colored cube from the top reserve cell down (on the playing field) is called 'MOVE'.");
						languages.Add("You have 10 moves and unlimited time on any level. But you have a higher rank in rating, when you spend less time and moves.");
						languages.Add("Your learning is over. You can always repeat it from the main menu of the game.");//80
						languages.Add("Finish");
						languages.Add("YES");
						languages.Add("NO");
						languages.Add("To register to participate in the leaderboard");
						languages.Add("You have passed all levels");
						languages.Add("Connect to internet to participate in the leaderboard");
						languages.Add("New game");
						languages.Add("You must be connected to the Internet \nfor sign-up and sign-in");
						languages.Add("Are you sure you want to leave?\nYour current level progress will not be saved");
				}

				if (PlayerPrefs.GetString ("languages") == "Ukrainian")
				{
						languages.Add("Продов-\nжити\nгру");//0
						languages.Add("Нова\nгра");
						languages.Add("Трену-\nвання");
						languages.Add("Навчання");
						languages.Add("Рейтинг\nгравців");
						languages.Add("Налашту-\nвання");
						languages.Add("Вихід");
						languages.Add("Оцінити\nгру");
						languages.Add("Звук:");
						languages.Add("Увімкнути");
						languages.Add("Вимкнути");//10
						languages.Add("Назад");//11
						languages.Add("ЗОЛОТО");
						languages.Add("ХОДІВ");
						languages.Add("ДОДАТИ");
						languages.Add("РІВЕНЬ");
						languages.Add("ЧАС");
						languages.Add("Легкий\nрестарт");
						languages.Add("Меню");
						languages.Add("Повернутися\nдо гри");//19
						languages.Add("Купити\nзолото");//20
						languages.Add("Вихід до\nменю");
						languages.Add("На даний час у Вас:");
						languages.Add("золота");
						languages.Add("Додоти ще:");
						languages.Add("золота за");
						languages.Add("Перейти до сплати");
						languages.Add("Деякі функції гри вимагають акаунта на нашому сервісі\nі постійного доступу до інтернету");
						languages.Add("Введіть свій логін:");
						languages.Add("Введіть свій пароль:");
						languages.Add("Увійти");//30
						languages.Add("Швидка реєстрація");
						languages.Add("Увійти без реєстрації");
						languages.Add("Повторіть пароль");
						languages.Add("Зареєструватися");
						languages.Add("Назад");
						languages.Add("Вітаємо!");
						languages.Add("Ви пройшли рівень");
						languages.Add("ВАШ ЧАС");
						languages.Add("ВАШІ ХОДИ");
						languages.Add("На наступний рівень");//40
						languages.Add("Повторити рівень");
						languages.Add("Не залишилось ходів");
						languages.Add("Вибачте, але Ви витратили свої ходи.");
						languages.Add("Виберіть один з варіантів");
						languages.Add("Додати ходів");
						languages.Add("Легкий рестарт");
						languages.Add("Головне\nменю");
						languages.Add("ходів за");
						languages.Add("купити");
						languages.Add("У кожного гравця є можливість використовувати кнопку легкий рестарт. При натисканні даної кнопки, рівень почнеться заново, але з самого початку у гравця будуть зібрані всі лінії, крім 2-х останніх.");//50
						languages.Add("Вартість:");
						languages.Add("ДОДАТИ ХОДИ");
						languages.Add("Легкий рестарт");
						languages.Add("Купити золото");
						languages.Add("ІМ'Я ГРАВЦЯ");
						languages.Add("ХОДИ");
						languages.Add("Зміна\nаккаунту");
						languages.Add("Перевірте введення даних.\nВ одному з полів помилка.");
						languages.Add("Даний логін вже зайнятий.");
						languages.Add("Перевірте введення даних.\nНе збігаються паролі або порожні поля введення");//60
						languages.Add("Перевірте введення даних.\nВи не ввели свій логін");
						languages.Add("Закрити");
						languages.Add("Змінити акаунт");
						languages.Add("ПІДТВЕРДИВШИ ЗМІНУ ЗАПИСУ:\nВИ ЗАЛИШИТЕ РІВЕНЬ\nІ ПЕРЕЙДЕТЕ НА СТОРІНКУ\nВХОДУ ТА РЕЄСТРАЦІЇ");
						languages.Add("ПІДТВЕРДИТИ");
						languages.Add("СКАСУВАТИ");
						languages.Add("Вибір\nрівня");
						languages.Add("Далі");
						languages.Add("Почати\nнавчання");//69
						languages.Add("Ласкаво просимо в нашу гру!");//70
						languages.Add("Для того, щоб розібратися з правилами гри, ми підготували для Вас коротке навчання.");
						languages.Add("Головна мета гри");
						languages.Add("зібрати кожен колір у вертикальну лінію");
						languages.Add("Гравець має можливість пересувати кольорові кубики по двох осях: по вертикалі і горизонталі");
						languages.Add("У гравця є можливість переміщати по вертикалі кожен кубик окремо");
						languages.Add("Але по горизонталі рухається весь рядок цілком");
						languages.Add("Вгорі ігрового поля є пересувна резервна клітинка, в яку можна тимчасово перемістити будь-який з кольорових кубиків, що знаходяться на верхній горизонталі.");
						languages.Add("Ходом вважається переміщення кольорового кубика з верхньої резервної клітинки вниз на ігрове поле.");
						languages.Add("На проходження рівня виділяється 10 ходів і необмежена кількість часу. Але чим менше часу і ходів Ви витратите, тим вище буде Ваша позиція в рейтингу.");
						languages.Add("Ваше навчання закінчено. Ви в будь-який момент можете повторити його з головного меню гри.");//80
						languages.Add("Закінчити");
						languages.Add("ТАК");
						languages.Add("НІ");
						languages.Add("Для участі у загальному рейтингу зареєструйтеся");
						languages.Add("Ви пройшли всі рівні");
						languages.Add("Для участі у загальному рейтингу підключіться до інтернету");
						languages.Add("Нова гра");
						languages.Add("Для реєстрації та входу до акаунту,\nнеобхідно підключення до мережі інтернет");
						languages.Add("Ви впевнені, що бажаєте вийти?\nУвесь Ваш поточний прогрес на рівні не буде збережений");
				}




		}

}