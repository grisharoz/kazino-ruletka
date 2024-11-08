# -*- coding: utf-8 -*-
import random
from listruletki_object import list_of_roulette

while True:
    start=input("Приветствую! Рады видеть тебя в одной из увлекательной и фартовой игре в мире :)\nГотов ли ты попытать свою удачу?(Выбери да/нет):")

    if start not in ["да", "нет"]:
        print("Такого варианта нет")
        continue

    break


if start=="да":
    print("\nСупер! Давай поскорее начнём играть)")
    choice=""
    str_type:str=''

    while True:
        try:
            money=int(input('Cколько ты хочешь поставить?:'))
        except ValueError:
            print("Такой ставки нет в списке. Попробуй ещё раз")
            continue

        bet=input("Выбери из переченя:'число','красное/чёрное','старшинство','ряд,'совокупность чисел','столбец','последовательность ',чётное/нечётное':")

        options = ["число", "красное/чёрное", "старшинство", "ряд", "совокупность чисел", "столбец", "последовательность", "чётное/нечётное"]

        if bet not in options:
            print("Такой ставки нет в списке. Попробуй ещё раз")
            continue

        if bet=='число':
            choice=input("Какое именно число от 0 дро 36 ты хочешь выбрать?:")
            

            if choice not in ['0','1','2','3','4','5','6','7','8','9','10','11','12','13','14','15','16','17','18','19','20','21','22','23','24','25','26','27','28','29','30','31','32','33','34','35','36']:
                print("Введена неправильная информация. Попробуй ещё раз.")
                continue


        if bet=='красное/чёрное':
            choice=input("Какой именно цвет ты хочешь выбрать?:")

            if choice not in ['красное','чёрное']:
                print("Введена неправильная информация. Попробуй ещё раз.")
                continue


        if bet=='старшинство':
            choice = input("Какую именно последовательность ты хочешь выбрать?(1-18/19-36):")

            if choice not in ['1-18','19-36']:
                print("Введена неправильная информация. Попробуй ещё раз.")
                continue


        if bet=="ряд":
            choice = input("Какой именно ряд ты хочешь выбрать(1,2,3)?:")

            if choice not in ['1','2','3']:
                print("Введена неправильная информация. Попробуй ещё раз.")
                continue

        if bet=='cовокупность':
            # TODO: Проверить правильность выбора пользователя
            choice = input("Какую именно совокупность чисел ты хочешь выбрать?(напиши её через слэш):")

        if bet=='столбец':
            choice = input("Какой именно столбец ты хочешь выбрать?(1-12):")
            if choice not in ['1','2','3','4','5','6','7','8','9','10','11','12']:
                print("Введена неправильная информация. Попробуй ещё раз.")
                continue


        if bet=='последователность':
            choice = input("Какую именно последовательность ты хочешь выбрать?(1-12/13-24/25-36):")
            if choice not in ['1-12','13-24','25-36']:
                print("Введена неправильная информация. Попробуй ещё раз.")
                continue



        if bet=='чётное/нечётное':
            choice = input("Ты выберишь чётное или нечётное?:")
            if choice not in ['чётное','нечётное']:
                print("Введена неправильная информация. Попробуй ещё раз.")
                continue



        again = input('Хочешь сделать ещё ставку?(да/нет):')
        if again == 'да':
            continue
        elif again == 'нет':
            print(
                "Рулетка крутиться!\nКто знает, может тебе сегодня улыбнётся удача??\nНа рулетке выпало:"
            )
            rand = random.choice(list(list_of_roulette))
            print(rand)

            if bet == "совокупность чисел":
                if choice in list_of_roulette[rand][bet]:
                    money *= 3
                    print("Ты выиграл! Вот твой выигрыш:", money)
                else:
                    print("Ты проиграл, но не расстраивайся :)")
            else: 
                if list_of_roulette[rand][bet]["значение"] == choice:
                    money *= list_of_roulette[rand][bet]["коеффициент"]
                    print("Ты выиграл! Вот твой выигрыш:", money)
                else:
                    print("Ты проиграл, но не расстраивайся :)")

        ending=input('\nТы хочешь ещё раз сыграть?:')
        if ending=="да":
            continue
        if ending=='нет':
            break

if start=="нет":
    print("\nПечально :(\nНо ты заходи если что. До следующего раза :)")