import * as Pixi from "pixi.js"
import Keyb from "keyb"

export default class Player extends Pixi.Sprite {
    constructor() {
        super(Pixi.Texture.from(require("images/pixel.png")))

        this.anchor.x = 0.5
        this.anchor.y = 0.5

        this.scale.x = 16
        this.scale.y = 16

        this.speed = 4

        this.position.x = 0
        this.position.y = 0
        
        this.velocity = new Pixi.Point()

        this.stack = 0
    }
    update(delta) {
        this.move(delta)
    }
    move(delta) {
        // inputs
        if(Keyb.isDown("<up>")) {
            this.velocity.y = -1 * this.speed * delta.f
        }
        if(Keyb.isDown("<down>")) {
            this.velocity.y = +1 * this.speed * delta.f
        }
        if(Keyb.isDown("<left>")) {
            this.velocity.x = -1 * this.speed * delta.f
        }
        if(Keyb.isDown("<right>")) {
            this.velocity.x = +1 * this.speed * delta.f
        }

        // translation from velocity
        this.position.x += this.velocity.x
        this.position.y += this.velocity.y

        // deceleration
        this.velocity.x = 0
        this.velocity.y = 0
    }
}
