using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    private Vector2Int[] directions = new Vector2Int[] {
        new Vector2Int(1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, 1),
        new Vector2Int(-1, -1)
    };

    public override List<Vector2Int> SelectAvailableSquares(){
        availableMoves.Clear();
        float range = 8; // maximum moving distance

        foreach(var direction in directions){
            for (int i = 1; i <= range; i++){
                Vector2Int nextCoords = occupiedSquare + direction * i;
                Piece piece = board.GetPieceOnSquare(nextCoords);
                if (!board.CheckIfCoordinateAreOnBoard(nextCoords)){
                    break;
                }
                if (piece == null){
                    TryToAddMove(nextCoords);
                } else if (!piece.IsFromSameTeam(this)) {
                    TryToAddMove(nextCoords);
                    break;
                } else if (piece.IsFromSameTeam(this)) {
                    break;
                }
            }
        }
        return availableMoves;
    }
}
