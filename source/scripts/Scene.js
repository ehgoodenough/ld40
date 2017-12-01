import * as Pixi from "pixi.js"

import Player from "scripts/Player.js"
import {FRAME} from "scripts/Constants.js"

export default class Scene extends Pixi.Container {
    constructor(scene) {
        super()
        
        this.player = null

        this.addChild(new Player())
    }
    update(delta) {
        this.children.forEach((child) => {
            if(child.update instanceof Function) {
                child.update(delta)
            }
        })

        // Sort by "stack" order.
        this.children.sort((a, b) => {
            if((a.stack || 0) < (b.stack || 0)) return -1
            if((a.stack || 0) > (b.stack || 0)) return +1
            return 0
        })

        // // Move the camera to center on the player.
        // this.position.x = -1 * (this.player.position.x - (FRAME.WIDTH / 2))
        // this.position.y = -1 * (this.player.position.y - (FRAME.HEIGHT / 2))
    }
    addChild(child) {
        super.addChild(child)

        if(child instanceof Player) {
            this.player = child
        }
    }
}
