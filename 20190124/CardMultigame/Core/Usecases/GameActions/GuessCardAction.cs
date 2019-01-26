﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.GameStates;
using Core.Entities.Cards;
using Core.Containers.GameRules;
using Core.Usecases.CardComparison;
using Core.Usecases.InfluenceState;
using Core.Entities.Decks;

namespace Core.Usecases.GameActions
{
    public class GuessCardAction : IGameAction
    {
        string _identifier = "Guess";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules rules, string orderParams)
        {
            Card chosenCard = new CardFactory().CreateSingle(orderParams);
            //DrawSingleCard()
            var action = new GameActionsFactory().HavingOrders("drawSingleCard").FirstOrDefault();
            action.ChangeGameState(currentGameState, rules, orderParams);
            //Compare
            var comparator = rules.CardComparator();
            var temp = currentGameState["DrawCard"] as Card;
            currentGameState[_identifier] = comparator.AreTheSame(currentGameState["DrawnCard"] as Card, chosenCard);
            //WriteResult
            rules.CheckGameStopConditions(currentGameState);
            rules.CheckVictoryConditions(currentGameState);

            //throw new NotImplementedException("Implement this. T212, GuessingACard command");
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
