import * as Pixi from "pixi.js"

import {getDirection} from "scripts/utilities/Geometry.js"

var ID = 1
var STACK = -10

export default class LevelLayer extends Pixi.Graphics {
    constructor(level) {
        super()

        this.id = ID++

        this.color = 0x444444 * this.id
        this.polygon = level.polygon.map(function(point) {
            return new Pixi.Point(level.x + point.x, level.y + point.y)
        })

        this.beginFill(this.color)
        this.drawPolygon(this.polygon)

        this.stack = STACK + (this.id * 0.1)
    }
    getY(x) {
        var points = this.polygon.map((point, index) => {
            return [
                this.polygon[index],
                this.polygon[(index + 1) % this.polygon.length]
            ]
        }).filter((points, index) => {
            return (points[0].x < x && x < points[1].x)
                || (points[1].x < x && x < points[0].x)
        })

        if(points.length == 0) {
            return undefined
        }

        return points.reduce((minY, points) => {
            var y = getDirection(points) * (x - points[0].x) + points[0].y
            return Math.min(minY, y)
        }, Number.MAX_SAFE_INTEGER)
    }
}
