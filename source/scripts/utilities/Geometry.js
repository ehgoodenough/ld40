export function getDirection(points) {
    if(points.length > 2) {
        throw "what"
    }

    return (points[0].y - points[1].y) / (points[0].x - points[1].x)
}
