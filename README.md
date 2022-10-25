# eSportAPI Documentation


```
GET /api/v1/games
```
### Description
Returns all active games
### Parameters
None
### Response

| Code | Description                  | Type         |
| ---- | ---------------------------- | ------------ |
| 200  | Success                      | Game Array   |

------------------------------------------------------


```
GET /api/v1/games/{game_id}/gametypes
```
### Description
Returns all GameTypes associated with a game
### Parameters
| Type    | Name         | Value            |
| ----    | ------------ | ---------------- |
| Header  | Content-type | application/json |
| Path    | game_id      | integer          |

### Response
| Code | Description                  | Type   |
| ---- | ---------------------------- | ------ |
| 200  | Success                      | Game   |
| 400  | Bad request/Missing argument | Error  |

------------------------------------------------------

```
POST /api/v1/games
```
### Description
Add a new game
### Parameters
| Type    | Name         | Value            |
| ----    | ------------ | ---------------- |
| Header  | Content-type | application/json |
| Body    | Content      | Game definition  |

### Response
| Code | Description                  | Type   |
| ---- | ---------------------------- | ------ |
| 200  | Success                      | Game   |
| 400  | Bad request/Missing argument | Error  |

------------------------------------------------------
