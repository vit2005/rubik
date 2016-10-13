using UnityEngine;
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
			languages.Add("ПРОДОЛЖИТЬ\nИГРУ");//0
			languages.Add("НОВАЯ\nИГРА");
			languages.Add("ТРЕНИРОВКА");
			languages.Add("ОБУЧЕНИЕ");
			languages.Add("РЕЙТИНГ\nИГРОКОВ");
			languages.Add("НАСТРОЙКИ");
			languages.Add("ВЫХОД");
			languages.Add("ОЦЕНИТЬ\nИГРУ");
			languages.Add("ЗВУК:");
			languages.Add("ВКЛЮЧИТЬ");
			languages.Add("ВЫКЛЮЧИТЬ");//10
			languages.Add("НАЗАД");
			languages.Add("ЗОЛОТО");
			languages.Add("ХОДОВ");
			languages.Add("ДОБАВИТЬ");
			languages.Add("УРОВЕНЬ");
			languages.Add("ВРЕМЯ");
			languages.Add("ЛЕГКИЙ\nРЕСТАРТ");
			languages.Add("МЕНЮ");
			languages.Add("ВЕРНУТЬСЯ В\nИГРУ");
			languages.Add("КУПИТЬ\nЗОЛОТО");//20
			languages.Add("ВЫХОД В\nМЕНЮ");
			languages.Add("На данный момент у Вас:");
			languages.Add("золота");
			languages.Add("ДОБАВИТЬ ЕЩЕ:");
			languages.Add("золота за");
			languages.Add("ПЕРЕЙТИ К ОПЛАТЕ");
			languages.Add("Некоторые функции игры требуют аккаунта на нашем сервисе\nи постоянного доступа в интернет");
			languages.Add("Введите свой логин:");
			languages.Add("Введите свой пароль:");
			languages.Add("Войти");//30
			languages.Add("Быстрая регистрация");
			languages.Add("Войти без регистрации");
			languages.Add("Повторите ввод пароля");
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
			languages.Add("ГЛАВНОЕ\nМЕНЮ");
			languages.Add("ходов за");
			languages.Add("КУПИТЬ");
			languages.Add("У каждого игрока есть возможность использовать кнопку легкий рестарт. При нажатии данной кнопки, уровень начнется заново, но с самого начала у игрока будут собраны все линии, кроме 2-х последних.");//50
			languages.Add("Стоимость:");
			languages.Add("ДОБАВИТЬ ХОДЫ");
			languages.Add("ЛЕГКИЙ РЕСТАРТ");
			languages.Add("КУПИТЬ ЗОЛОТО");
			languages.Add("ИМЯ ИГРОКА");
			languages.Add("ХОДЫ");
			languages.Add("СМЕНА\nАККАУНТА");
			languages.Add("Проверьте ввод данных.\nВ одном из полей ошибка.");
			languages.Add("Данный логин уже занят.");
			languages.Add("Проверьте ввод данных.\nНе совпадают пароли или пустые поля ввода");//60
			languages.Add("Проверьте ввод данных.\nВы не ввели свой логин");
			languages.Add("Закрыть");
			languages.Add("Сменить аккаунт");
			languages.Add("ПОДТВЕРДИВ СМЕНУ АККАУНТА:\nВЫ ПОКИНЕТЕ УРОВЕНЬ\nИ ПЕРЕЙДЕТЕ НА СТРАНИЦУ\nВХОДА И РЕГИСТРАЦИИ");
			languages.Add("ПОДТВЕРДИТЬ");
			languages.Add("ОТМЕНА");
			languages.Add("ВЫБОР\nУРОВНЯ");
			languages.Add("Продолжить\nобучение");
			languages.Add("Начать\nобучение");//69
			languages.Add("Добро пожаловать в нашу игру!");//70
			languages.Add("Для того, чтобы\nразобраться с\nправилами игры,\nмы подготовили\nдля Вас короткое обучение.");
			languages.Add("Главная цель игры");
			languages.Add("собрать каждый\nцвет\nв вертикальную линию");
			languages.Add("Игрок имеет возможность\nпередвигать цветные\nкубики по двум осям:\nпо вертикали и горизонтали");
			languages.Add("У игрока есть\nвозможность перемещать\nпо вертикали каждый\nкубик по отдельности");
			languages.Add("Но по горизонтали\nдвигается вся\nстрока целиком");
			languages.Add("Вверху игрового поля\nесть перемещаемая резервная ячейка,\nв которую можно временно переместить\nлюбой из цветных кубиков,\nнаходящихся на верхней горизонтали.");
			languages.Add("Ходом считается\nперемещение цветного кубика\nиз верхней резервной\nячейки вниз на игровое поле.");
			languages.Add("На прохождение уровня\nвыделяется 10 ходов и\nнеограниченное количество времени.\nНо чем меньше времени и ходов\nВы потратите - тем выше будет\nВаша позиция в рейтинге.");
			languages.Add("Ваше обучение окончено.\nВы в любой момент можете повторить его из главного\nменю игры.");//80
			languages.Add("Закончить\nобучение");
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
			languages.Add("CONTINUE\nGAME");
			languages.Add("NEW\nGAME");
			languages.Add("TRAINING\nROOM");
			languages.Add("LEARNING");
			languages.Add("LEADER\nBOARD");
			languages.Add("SETTINGS");
			languages.Add("EXIT");
			languages.Add("RATE\nTHIS GAME");
			languages.Add("SOUND:");
			languages.Add("ON");
			languages.Add("OFF");//10
			languages.Add("BACK");
			languages.Add("GOLD");//12
			languages.Add("MOVES");//13
			languages.Add("ADD");//14
			languages.Add("LEVEL");//15
			languages.Add("TIME");//16
			languages.Add("EASY\nRESTART");
			languages.Add("MENU");
			languages.Add("BACK\nTO GAME");
			languages.Add("BUY\nGOLD");//20
			languages.Add("EXIT\nTO MENU");
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
			languages.Add("MAIN\nMENU");
			languages.Add("moves for");
			languages.Add("BUY");
			languages.Add("Each player has the opportunity to use the button   'EASY RESTART'. When this button is pressed, the level will restart. But the player has collected all lines from the beginning except the last 2.");//50
			languages.Add("Cost:");
			languages.Add("ADD MOVES");
			languages.Add("EASY RESTART");
			languages.Add("BUY GOLD");
			languages.Add("PLAYER NAME");
			languages.Add("MOVES");
			languages.Add("CHANGE\nACCOUNT");
			languages.Add("Check the input data.\nOne of the fields has error.");
			languages.Add("This login is already in use.");
			languages.Add("Check the input data.\nPassword does not match or an empty input field");//60
			languages.Add("Check the input data.\nYou did not enter your username");
			languages.Add("Close");
			languages.Add("Change account");
			languages.Add("IF YOY CONFIRM\nYOU LEAVE THE LEVEL\nAND GO TO THE LOGIN PAGE");
			languages.Add("CONFIRM");
			languages.Add("CANCEL");
			languages.Add("SELECT\nLEVEL");
			languages.Add("Continue\nlearning");
			languages.Add("Start\nlearning");//69
			languages.Add("Welcome to our game!");//70
			languages.Add("In order to\nunderstand the rules\nof the game,\nwe have prepared\nfor You a short training."); //71
			languages.Add("The main goal of the game");//72
			languages.Add("is collect every\ncolor\nin a vertical line");
			languages.Add("The player has the ability\nto move the colored\ncubes along two axes:\nvertically and horizontally");
			languages.Add("The player\nhas the ability\nto move vertically each\ncube individually");
			languages.Add("But the horizontal\nstring is moving\nentirely");
			languages.Add("At the top of the game board\nyou can see movable reserve cell.\nYou can temporarily move  to this cell\nany of the colored blocks,\nwhich located in the upper horizontally.");
			languages.Add("The movement of colored\ncube from the top reserve cell\ndown (on the playing field)\nis called 'MOVE'.");
			languages.Add("You have 10 moves and\nunlimited time on any level.\nBut you have a higher rank\nin rating, when you\nspend less time and moves.");
			languages.Add("Your learning is over.\nYou can always repeat it\nfrom the main menu of the game.");//80
			languages.Add("Finish\nthe game\nlearning");
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
			languages.Add("ПРОДОВЖИТИ\nГРУ");//0
			languages.Add("НОВА\nГРА");
			languages.Add("ТРЕНУВАННЯ");
			languages.Add("НАВЧАННЯ");
			languages.Add("РЕЙТИНГ\nГРАВЦІВ");
			languages.Add("НАЛАШТУВАННЯ");
			languages.Add("ВИХІД");
			languages.Add("ОЦІНИТИ\nГРУ");
			languages.Add("ЗВУК:");
			languages.Add("УВІМКНУТИ");
			languages.Add("ВИМКНУТИ");//10
			languages.Add("НАЗАД");
			languages.Add("ЗОЛОТО");
			languages.Add("ХОДІВ");
			languages.Add("ДОДАТИ");
			languages.Add("РІВЕНЬ");
			languages.Add("ЧАС");
			languages.Add("ЛЕГКИЙ\nРЕСТАРТ");
			languages.Add("МЕНЮ");
			languages.Add("ВЕРНУТИСЯ\nДО ГРИ");
			languages.Add("КУПИТИ\nЗОЛОТО");//20
			languages.Add("ВИХІД ДО\nМЕНЮ");
			languages.Add("На даний час у Вас:");
			languages.Add("золота");
			languages.Add("ДОДАТИ ЩЕ:");
			languages.Add("золота за");
			languages.Add("ПЕРЕЙТИ ДО СПЛАТИ");
			languages.Add("Деякі функції гри вимагають акаунта на нашому сервісі\nі постійного доступу до інтернету");
			languages.Add("Введіть свій логін:");
			languages.Add("Введіть свій пароль:");
			languages.Add("Увійти");//30
			languages.Add("Швидка реєстрація");
			languages.Add("Увійти без реєстрації");
			languages.Add("Повторіть введення паролю");
			languages.Add("Зареєструватися");
			languages.Add("Назад");
			languages.Add("Вітаємо!");
			languages.Add("Ви пройшли рівень");
			languages.Add("ВАШ ЧАС");
			languages.Add("ВАШІ ХОДИ");
			languages.Add("На наступний рівень");//40
			languages.Add("Повторити рівень");
			languages.Add("НЕ ЗАЛИШИЛОСЬ ХОДІВ");
			languages.Add("Вибачте, але Ви витратили свої ходи.");
			languages.Add("Виберіть один з варіантів");
			languages.Add("Додати ходів");
			languages.Add("Легкий рестарт");
			languages.Add("ГОЛОВНЕ\nМЕНЮ");
			languages.Add("ходів за");
			languages.Add("КУПИТИ");
			languages.Add("У кожного гравця є можливість використовувати кнопку легкий рестарт. При натисканні даної кнопки, рівень почнеться заново, але з самого початку у гравця будуть зібрані всі лінії, крім 2-х останніх.");//50
			languages.Add("Вартість:");
			languages.Add("ДОДАТИ ХОДИ");
			languages.Add("ЛЕГКИЙ РЕСТАРТ");
			languages.Add("КУПИТИ ЗОЛОТО");
			languages.Add("ІМ'Я ГРАВЦЯ");
			languages.Add("ХОДИ");
			languages.Add("ЗМІНА\nАКАУНТУ");
			languages.Add("Перевірте введення даних.\nВ одному з полів помилка.");
			languages.Add("Даний логін вже зайнятий.");
			languages.Add("Перевірте введення даних.\nНе збігаються паролі або порожні поля введення");//60
			languages.Add("Перевірте введення даних.\nВи не ввели свій логін");
			languages.Add("Закрити");
			languages.Add("Змінити акаунт");
			languages.Add("ПІДТВЕРДИВШИ ЗМІНУ ЗАПИСУ:\nВИ ЗАЛИШИТЕ РІВЕНЬ\nІ ПЕРЕЙДЕТЕ НА СТОРІНКУ\nВХОДУ ТА РЕЄСТРАЦІЇ");
			languages.Add("ПІДТВЕРДИТИ");
			languages.Add("СКАСУВАТИ");
			languages.Add("ВИБІР\nРІВНЯ");
			languages.Add("Продовжити\nнавчання");
			languages.Add("Почати\nнавчання");//69
			languages.Add("Ласкаво просимо в нашу гру!");//70
			languages.Add("Для того, щоб\nрозібратися з\nправилами гри,\nми підготували\nдля Вас коротке навчання.");
			languages.Add("Головна мета гри");
			languages.Add("зібрати кожен\nколір\nу вертикальну лінію");
			languages.Add("Гравець має можливість\nпересувати кольорові\nкубики по двох осях:\nпо вертикалі і горизонталі");
			languages.Add("У гравця є\nможливість переміщати\nпо вертикалі кожен\nкубик окремо");
			languages.Add("Але по горизонталі\nрухається весь\nрядок цілком");
			languages.Add("Вгорі ігрового поля\nє пересувна резервна клітинка,\nв яку можна тимчасово перемістити\nбудь-який з кольорових кубиків,\nщо знаходяться на верхній горизонталі.");
			languages.Add("Ходом вважається\nпереміщення кольорового кубика\nз верхньої резервної\nклітинки вниз на ігрове поле.");
			languages.Add("На проходження рівня\nвиділяється 10 ходів і\nнеобмежена кількість часу.\nАле чим менше часу і ходів\nВи витратите, тим вище буде\nВаша позиція в рейтингу.");
			languages.Add("Ваше навчання закінчено.\nВи в будь-який момент можете \nповторити його з головного меню гри.");//80
			languages.Add("Закінчити\nнавчання");
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