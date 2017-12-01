import * as Pixi from "pixi.js"

import Scene from "scripts/Scene.js"
import {FRAME} from "scripts/Constants.js"

export default class Game extends Pixi.Container {
    constructor() {
        super()

        window.game = this

        this.renderer = Pixi.autoDetectRenderer({
            width: FRAME.WIDTH * FRAME.SCALE,
            height: FRAME.HEIGHT * FRAME.SCALE,
            transparent: true
        })

        this.scale.x = FRAME.SCALE
        this.scale.y = FRAME.SCALE

        this.addChild(this.scene = new Scene())
    }
    update(delta) {
        this.children.forEach((child) => {
            if(child.update instanceof Function) {
                child.update(delta)
            }
        })
    }
    render() {
        this.renderer.render(this)
    }
}
